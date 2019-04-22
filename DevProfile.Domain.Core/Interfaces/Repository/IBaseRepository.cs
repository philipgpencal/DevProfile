using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DevProfile.Domain.Core.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll();
        void Save(T entity);
        T GetById(int id);
        void Delete(T entity);
        List<T> QueryByPage(out int maxpage, int page = 0, int pageSize = 3, Expression<Func<T, bool>> predicate = null);
        List<T> Where(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        void AddRangeAndSave(List<T> entityList);
        List<T> GetRandom(int numberOfItens);
    }
}
