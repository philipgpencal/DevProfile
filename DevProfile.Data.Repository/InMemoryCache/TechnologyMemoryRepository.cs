using DevProfile.Data.Repository.InMemoryCache;
using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using Microsoft.Extensions.Caching.Memory;

namespace DevProfile.Data.Repository
{
    public class TechnologyMemoryRepository : BaseMemoryRepository<Technology>, ITechnologyRepository
    {
        private IMemoryCache memoryCache;

        public TechnologyMemoryRepository(IMemoryCache memoryCache) : base (memoryCache)
        {
            this.memoryCache = memoryCache;
        }
    }
}
