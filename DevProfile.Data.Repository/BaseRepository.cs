using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Infrastructure.CrossCutting.Extension;
using DevProfile.Infrastructure.DataBase.DevProfileDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DevProfile.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DevProfileContext devProfileContext;

        public BaseRepository(DevProfileContext devProfileContext)
        {
            this.devProfileContext = devProfileContext;
        }

        public virtual List<T> GetAll()
        {
            return devProfileContext.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return devProfileContext.Set<T>().Find(id);
        }

        public virtual void Save(T entity)
        {
            int id = (int)entity.GetType().GetProperty("Id").GetValue(entity);

            if (id == 0)
            {
                devProfileContext.Set<T>().Add(entity);
            }
            else
            {
                devProfileContext.Set<T>().Update(entity);
            }

            devProfileContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            devProfileContext.Set<T>().Remove(entity);
            devProfileContext.SaveChanges();
        }

        public virtual List<T> QueryByPage(out int maxpage, int page = 0, int pageSize = 3, Expression<Func<T, bool>> predicate = null)
        {
            predicate = predicate ?? (a => true);
            var count = devProfileContext.Set<T>().Where(predicate).Count();
            var data = devProfileContext.Set<T>().Where(predicate).Skip(page * pageSize).Take(pageSize).ToList();

            maxpage = (int)Math.Ceiling((decimal)count / (decimal)pageSize);

            return data;
        }

        public virtual List<T> Where(Expression<Func<T, bool>> predicate)
        {
            return devProfileContext.Set<T>().Where(predicate).ToList();
        }

        public virtual void AddRangeAndSave(List<T> entityList)
        {
            devProfileContext.Set<T>().AddRange(entityList);
            devProfileContext.SaveChanges();
        }

        public virtual List<T> GetRandom(int numberOfItens)
        {
            return devProfileContext.Set<T>().PickRandom(numberOfItens).ToList();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return devProfileContext.Set<T>().Any(predicate);
        }
    }
}
