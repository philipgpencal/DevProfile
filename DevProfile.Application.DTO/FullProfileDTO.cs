using DevProfile.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace DevProfile.Application.DTO
{
    public class FullProfileDTO
    {
        public FullProfileDTO()
        {

        }

        public FullProfileDTO(Developer developer)
        {
            DeveloperName = developer.Name;
            DeveloperId = developer.Id;

            if(developer.Skills != null && developer.Skills.Any())
            {
                foreach (var skill in developer.Skills)
                {
                    StackList.Add(new StackDTO
                    {
                        Name = skill.Stack.Name,
                        Description = skill.Stack.Description
                    });

                    TechnologyList.Add(new TechnologyDTO
                    {
                        Name = skill.Technology.Name,
                        Description = skill.Technology.Description
                    });
                }
            }
        }

        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public List<StackDTO> StackList { get; set; } = new List<StackDTO>();
        public List<TechnologyDTO> TechnologyList { get; set; } = new List<TechnologyDTO>();

        public static List<FullProfileDTO> GetFromSkillList(List<Skill> skills)
        {
            var profileList = new List<FullProfileDTO>();

            foreach(int develperId in skills.Select(s => s.DeveloperId).Distinct())
            {
                var profile = new FullProfileDTO();
                var developer = skills.First(s => s.DeveloperId == develperId).Developer;
                var developerSkills = skills.Where(s => s.DeveloperId == develperId);

                profile.DeveloperId = developer.Id;
                profile.DeveloperName = developer.Name;

                foreach(var skill in developerSkills)
                {
                    profile.StackList.Add(new StackDTO
                    {
                        Name = skill.Stack.Name,
                        Description = skill.Stack.Description
                    });

                    profile.TechnologyList.Add(new TechnologyDTO
                    {
                        Name = skill.Technology.Name,
                        Description = skill.Technology.Description
                    });
                }

                profileList.Add(profile);
            }

            return profileList;
        }
    }
}
