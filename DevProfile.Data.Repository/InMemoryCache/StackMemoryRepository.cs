using DevProfile.Data.Repository.InMemoryCache;
using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using Microsoft.Extensions.Caching.Memory;

namespace DevProfile.Data.Repository
{
    public class StackMemoryRepository : BaseMemoryRepository<Stack>, IStackRepository
    {
        private IMemoryCache memoryCache;

        public StackMemoryRepository(IMemoryCache memoryCache) : base (memoryCache)
        {
            this.memoryCache = memoryCache;
        }
    }
}
