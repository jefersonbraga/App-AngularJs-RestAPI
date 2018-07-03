using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Cursos.Api.Controllers
{
    public partial class OrgaoemissorController
    {
        /// <summary>
        /// Method GetAll() [m_Orgaoemissor]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Orgaoemissor]</returns>
        [Route("getByOrgao/{orgao}")]
        public HttpResponseMessage GetByOrgao(string orgao)
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_OrgaoemissorBusiness.GetByOrgao(orgao));
        }
    }
}