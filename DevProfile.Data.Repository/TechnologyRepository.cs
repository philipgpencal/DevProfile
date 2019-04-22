using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using DevProfile.Infrastructure.DataBase.DevProfileDB;

namespace DevProfile.Data.Repository
{
    public class TechnologyRepository : BaseRepository<Technology>, ITechnologyRepository
    {
        private readonly DevProfileContext devProfileContext;

        public TechnologyRepository(DevProfileContext devProfileContext) : base(devProfileContext)
        {
            this.devProfileContext = devProfileContext;
        }
    }
}
