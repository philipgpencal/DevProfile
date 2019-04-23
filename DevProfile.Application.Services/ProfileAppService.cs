using DevProfile.Application.DTO;
using DevProfile.Application.Services.Interfaces;
using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevProfile.Application.Services
{
    public class ProfileAppService : IProfileAppService
    {
        private readonly ISkillRepository skillRepository;
        private readonly IDeveloperRepository developerRepository;
        private readonly IStackRepository stackRepository;
        private readonly ITechnologyRepository technologyRepository;

        public ProfileAppService(ISkillRepository skillRepository, IDeveloperRepository developerRepository,
            IStackRepository stackRepository, ITechnologyRepository technologyRepository)
        {
            this.skillRepository = skillRepository;
            this.developerRepository = developerRepository;
            this.stackRepository = stackRepository;
            this.technologyRepository = technologyRepository;
        }

        public void DeleteProfile(int developerId)
        {
            var skills = skillRepository.GetByDeveloperId(developerId);

            skillRepository.DeleteList(skills);
            developerRepository.DeleteList(skills.Select(s => s.Developer).ToList());
            stackRepository.DeleteList(skills.Select(s => s.Stack).ToList());
            technologyRepository.DeleteList(skills.Select(s => s.Technology).ToList());
        }

        public List<FullProfileDTO> GetAll()
        {
            var skills = skillRepository.GetAll();
            return FullProfileDTO.GetFromSkillList(skills);
        }

        public FullProfileDTO GetByDeveloperId(int developerId)
        {
            var skills = skillRepository.GetByDeveloperId(developerId);
            return FullProfileDTO.GetFromSkillList(skills).Single();
        }

        public void SaveNewProfile(ProfileDTO profileDTO)
        {
            var developer = new Developer
            {
                Name = profileDTO.DeveloperName
            };

            // Validations
            if (string.IsNullOrWhiteSpace(profileDTO.StackName))
            {
                throw new Exception("Include some parameters validatins here :)");
            }

            var technology = new Technology
            {
                Name = profileDTO.TechnologyName,
                Description = profileDTO.TechnologyDescription,
                Enabled = true
            };

            var stack = new Stack
            {
                Name = profileDTO.StackName,
                Description = profileDTO.StackDescription,
                Enabled = true
            };

            var skill = new Skill
            {
                Developer = developer,
                Stack = stack,
                Technology = technology
            };

            skillRepository.Save(skill);
        }
    }
}
