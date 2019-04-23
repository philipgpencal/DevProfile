using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Core.Interfaces.Services;
using DevProfile.Domain.Model;
using System.Collections.Generic;

namespace DevProfile.Domain.Services
{
    public class SkillService : BaseService<Skill>, ISkillService
    {
        private readonly ISkillRepository skillRepository;

        public SkillService(ISkillRepository skillRepository) : base(skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public List<Skill> GetByDeveloperId(int developerId)
        {
            return skillRepository.GetByDeveloperId(developerId);
        }
    }
}
