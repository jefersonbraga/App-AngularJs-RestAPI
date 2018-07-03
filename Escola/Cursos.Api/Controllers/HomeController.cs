using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Cursos.Api.Controllers.Base;
using Cursos.Business.Interfaces;

namespace Cursos.Api.Controllers
{
    /// <summary>
    /// Public partial Class [AcoesService]
    /// </summary>
	[RoutePrefix("services/home")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : BaseController
    {
        private readonly IHomeBusiness m_HomeBusiness;

        public HomeController(IHomeBusiness homeBusiness)
        {
            m_HomeBusiness = homeBusiness;
        }

        [Route("getmenu")]
        public HttpResponseMessage GetMenu(HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.OK, m_HomeBusiness.GetMenu());
        }
    }
}
