using DevProfile.Data.Repository.InMemoryCache;
using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using Microsoft.Extensions.Caching.Memory;

namespace DevProfile.Data.Repository
{
    public class DeveloperMemoryRepository : BaseMemoryRepository<Developer>, IDeveloperRepository
    {
        private IMemoryCache memoryCache;

        public DeveloperMemoryRepository(IMemoryCache memoryCache) : base (memoryCache)
        {
            this.memoryCache = memoryCache;
        }
    }
}
