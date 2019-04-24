using DevProfile.Data.Repository.InMemoryCache;
using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevProfile.Data.Repository
{
    public class SkillMemoryRepository : BaseMemoryRepository<Skill>, ISkillRepository
    {
        private IMemoryCache memoryCache;

        public SkillMemoryRepository(IMemoryCache memoryCache) : base(memoryCache)
        {
            this.memoryCache = memoryCache;

            SkillType = typeof(Skill);

            SkillList = memoryCache.GetOrCreate(GenericType.ToString(), entry =>
           {
               return new List<Skill>();
           });
        }

        public Type SkillType { get; set; }
        public List<Skill> SkillList { get; set; }

        public List<Skill> GetByDeveloperId(int developerId)
        {
            return SkillList.Where(s => s.DeveloperId == developerId).ToList();
        }
    }
}
