using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;

namespace Cursos.Repository.Services.Base
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Create T Object
        /// </summary>
        /// <param name="entity">Entity Object</param>
        void Add(T entity);

        /// <summary>
        /// Create T Object
        /// </summary>
        /// <param name="entity">Entity Object</param>
        void Add(IEnumerable<T> entity);

        /// <summary>
        ///Delete T Object
        /// </summary>
        /// <param name="entity">/Entity Object</param>
        void Delete(T entity);

        /// <summary>
        /// Get Object All
        /// </summary>
        /// <returns>HttpResponseMessage Object JSON</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Update T Object
        /// </summary>
        /// <param name="entity">Entity Object</param>
        void Update(T entity);

        /// <summary>
        /// Get Object By ID
        /// </summary>
        /// <returns>HttpResponseMessage Object JSON</returns>
        T GetById(int id);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        int Commit();
    }
}