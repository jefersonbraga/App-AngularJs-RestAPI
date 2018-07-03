using System;
using System.Collections.Generic;

namespace Cursos.Business.Interfaces
{
    public interface IBaseBusiness<T> where T : class
    {
        /// <summary>
        /// Create T Object
        /// </summary>
        /// <param name="entity">Entity Object</param>
        int Add(T entity);

        /// <summary>
        ///Delete T Object
        /// </summary>
        /// <param name="entity">/Entity Object</param>
        int Delete(T entity);

        /// <summary>
        /// Get Object All
        /// </summary>
        /// <returns>HttpResponseMessage Object JSON</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Update T Object
        /// </summary>
        /// <param name="entity">Entity Object</param>
        int Update(T entity);

        /// <summary>
        /// Get Object By ID
        /// </summary>
        /// <returns>HttpResponseMessage Object JSON</returns>
        T GetById(int id);

        //int Commit();
    }
}
