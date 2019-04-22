using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using DevProfile.Infrastructure.DataBase.DevProfileDB;

namespace DevProfile.Data.Repository
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        private readonly DevProfileContext devProfileContext;

        public SkillRepository(DevProfileContext devProfileContext) : base(devProfileContext)
        {
            this.devProfileContext = devProfileContext;
        }
    }
}
