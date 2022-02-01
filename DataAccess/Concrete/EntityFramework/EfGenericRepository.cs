using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {

        Context context = new Context();
        DbSet<T> _object;

        public EfGenericRepository()
        {
            _object = context.Set<T>();
        }

        public void Delete(T entity)
        {
            _object.Remove(entity);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Insert(T entity)
        {
            _object.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.SaveChanges();
        }
    }
}
