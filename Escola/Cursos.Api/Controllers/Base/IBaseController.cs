using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cursos.Api.Controllers.Base
{
    public interface IBaseController<T> where T : class
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        HttpResponseMessage GetAll();

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HttpResponseMessage GetById(int id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        HttpResponseMessage Add(T request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        HttpResponseMessage Update(T request);
    }
}