using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cursos.Repository.Base
{
    /// <summary>
    /// Interface Generic Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository <T> where T : class 
    {
        /// <summary>
        /// Get All T
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Find By Id T
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Add By T
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);
        /// <summary>
        /// Add Range By T
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IEnumerable<T> Add(IEnumerable<T> entity);
        /// <summary>
        /// Delete T
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Delete(T entity);
        /// <summary>
        /// Edit T
        /// </summary>
        /// <param name="entity"></param>
        void Edit(T entity);
        /// <summary>
        /// Save T
        /// </summary>
        void Save();
    }
}
