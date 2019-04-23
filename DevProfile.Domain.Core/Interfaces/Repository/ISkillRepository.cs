using DevProfile.Domain.Model;
using System.Collections.Generic;

namespace DevProfile.Domain.Core.Interfaces.Repository
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
        List<Skill> GetByDeveloperId(int developerId);
    }
}
