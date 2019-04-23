using DevProfile.Domain.Model;
using System.Collections.Generic;

namespace DevProfile.Domain.Core.Interfaces.Services
{
    public interface ISkillService : IBaseService<Skill>
    {
        List<Skill> GetByDeveloperId(int developerId);
    }
}
