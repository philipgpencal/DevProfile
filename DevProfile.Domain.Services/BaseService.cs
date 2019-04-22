using DevProfile.Domain.Core.Interfaces.Repository;
using DevProfile.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevProfile.Domain.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public void AddRangeAndSave(List<T> entityList)
        {
            baseRepository.AddRangeAndSave(entityList);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return baseRepository.Any(predicate);
        }

        public virtual void Delete(T entity)
        {
            baseRepository.Delete(entity);
        }

        public virtual List<T> GetAll()
        {
            return baseRepository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public List<T> GetRandom(int numberOfItens)
        {
            return baseRepository.GetRandom(numberOfItens);
        }

        public virtual List<T> QueryByPage(out int maxpage, int page = 0, int pageSize = 3, Expression<Func<T, bool>> predicate = null)
        {
            return baseRepository.QueryByPage(out maxpage, page, pageSize, predicate);
        }

        public virtual void Save(T entity)
        {
            baseRepository.Save(entity);
        }

        public virtual List<T> Where(Expression<Func<T, bool>> predicate)
        {
            return baseRepository.Where(predicate);
        }
    }
}
