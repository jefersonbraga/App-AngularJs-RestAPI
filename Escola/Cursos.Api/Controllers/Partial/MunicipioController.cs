using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cursos.Api.Controllers
{
    public partial class MunicipioController
    {
        /// <summary>
        /// Method GetAll() [m_Municipio]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Municipio]</returns>
        [Route("getcontains/{term}")]
        public HttpResponseMessage GetContains(string term)
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_MunicipioBusiness.GetContains(term));
        }
    }
}
