using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Model;
using DevProfile.Infrastructure.CrossCutting.Extension;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DevProfile.Data.Repository.InMemoryCache
{
    public abstract class BaseMemoryRepository<T> : IBaseRepository<T> where T : class
    {
        private IMemoryCache memoryCache;

        public BaseMemoryRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            GenericType = typeof(T);

            GenericList = memoryCache.GetOrCreate(GenericType.ToString(), entry =>
            {
                return new List<T>();
            });
        }

        public Type GenericType { get; set; }
        public List<T> GenericList { get; set; }

        public virtual List<T> GetAll()
        {
            return GenericList;
        }

        public virtual T GetById(int id)
        {
            return GenericList.Where(t => (int)t.GetType().GetProperty("Id").GetValue(t) == id).Single();
        }

        public virtual void Save(T entity)
        {
            int id = (int)entity.GetType().GetProperty("Id").GetValue(entity);

            if (id != 0)
            {
                T old = GenericList.Where(t => (int)t.GetType().GetProperty("Id").GetValue(t) == id).Single();
                GenericList.Remove(old);
            }
            else
            {
                foreach (var property in entity.GetType().GetProperties())
                {
                    if (property.Name.EndsWith("Id"))
                    {
                        entity.GetType().GetProperty(property.Name).SetValue(entity, GenericList.Count + 1);
                    }
                }
            }

            GenericList.Add(entity);
            memoryCache.Set(GenericType.ToString(), GenericList);
        }

        public virtual void Delete(T entity)
        {
            GenericList.Remove(entity);
            memoryCache.Set(GenericType.ToString(), GenericList);
        }

        public virtual void DeleteList(List<T> entities)
        {
            foreach (T entity in entities)
            {
                GenericList.Remove(entity);
            }

            memoryCache.Set(GenericType.ToString(), GenericList);
        }

        public virtual List<T> QueryByPage(out int maxpage, int page = 0, int pageSize = 3, Expression<Func<T, bool>> predicate = null)
        {
            predicate = predicate ?? (a => true);
            var count = GenericList.Where(predicate.Compile()).Count();
            var data = GenericList.Where(predicate.Compile()).Skip(page * pageSize).Take(pageSize).ToList();

            maxpage = (int)Math.Ceiling((decimal)count / (decimal)pageSize);

            return data;
        }

        public virtual List<T> Where(Expression<Func<T, bool>> predicate)
        {
            return GenericList.Where(predicate.Compile()).ToList();
        }

        public virtual void AddRangeAndSave(List<T> entityList)
        {
            GenericList.AddRange(entityList);
            memoryCache.Set(GenericType.ToString(), GenericList);
        }

        public virtual List<T> GetRandom(int numberOfItens)
        {
            return GenericList.PickRandom(numberOfItens).ToList();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return GenericList.Any(predicate.Compile());
        }
    }
}
