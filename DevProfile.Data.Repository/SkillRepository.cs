using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using DevProfile.Infrastructure.DataBase.DevProfileDB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DevProfile.Data.Repository
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        private readonly DevProfileContext devProfileContext;

        public SkillRepository(DevProfileContext devProfileContext) : base(devProfileContext)
        {
            this.devProfileContext = devProfileContext;
        }

        public override List<Skill> GetAll()
        {
            return devProfileContext.Skills
                .Include(s => s.Developer)
                .Include(s => s.Stack)
                .Include(s => s.Technology)
                .ToList();
        }

        public List<Skill> GetByDeveloperId(int developerId)
        {
            return devProfileContext.Skills
                .Include(s => s.Developer)
                .Include(s => s.Stack)
                .Include(s => s.Technology)
                .Where(s => s.DeveloperId == developerId).ToList();
        }
    }
}
