using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using DevProfile.Infrastructure.DataBase.DevProfileDB;


namespace DevProfile.Data.Repository
{
    public class StackRepository : BaseRepository<Stack>, IStackRepository
    {
        private readonly DevProfileContext devProfileContext;

        public StackRepository(DevProfileContext devProfileContext) : base(devProfileContext)
        {
            this.devProfileContext = devProfileContext;
        }
    }
}
