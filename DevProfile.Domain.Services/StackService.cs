using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Core.Interfaces.Services;
using DevProfile.Domain.Model;

namespace DevProfile.Domain.Services
{
    public class StackService : BaseService<Stack>, IStackService
    {
        private readonly IStackRepository stackRepository;

        public StackService(IStackRepository stackRepository) : base(stackRepository)
        {
            this.stackRepository = stackRepository;
        }
    }
}
