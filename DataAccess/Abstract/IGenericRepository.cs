using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IGenericRepository<T>
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
