using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cursos.Api.Controllers
{
    public partial class UfController
    {
        /// <summary>
        /// Method GetAll() [m_Uf]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Uf]</returns>
        [Route("getByUf/{uf}")]
        public HttpResponseMessage GetByUf(string uf)
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_UfBusiness.GetByUf(uf));
        }
    }
}
