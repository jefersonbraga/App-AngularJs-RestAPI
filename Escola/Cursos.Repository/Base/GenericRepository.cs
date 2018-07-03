using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Cursos.Repository.Base
{
    /// <summary>
    /// Generic Repository Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericRepository<T> : IGenericRepository<T>
      where T : class
    {
        protected DbContext Entities;
        protected readonly IDbSet<T> Dbset;

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        protected GenericRepository(DbContext context)
        {
            Entities = context;
            Dbset = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return Dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = Dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return Entities.Set<T>().Add(entity);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> Add(IEnumerable<T> entity)
        {
            return Entities.Set<T>().AddRange(entity);
        }

        public virtual T Delete(T entity)
        {
            Entities.Entry(entity).State = EntityState.Deleted;
            return Dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            Entities.SaveChanges();
        }
    }
}