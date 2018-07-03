using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Cursos.Api.Controllers
{
    public partial class EventoController
    {
        /// <summary>
        /// Method GetAll() [m_Cliente]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Cliente]</returns>
        [Route("GetAllCombo")]
        public HttpResponseMessage GetAllCombo()
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_EventoBusiness.GetAllCombo());
        }

        /// <summary>
        /// Method GetAll() [m_Cliente]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Cliente]</returns>
        [Route("GetPaginacao")]
        public HttpResponseMessage GetPaginacao(string order, int offset, int limit)
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_EventoBusiness.GetEventoPaginacao(order, offset, limit));
        }

        /// <summary>
        /// Method GetAll() [m_Cliente]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Cliente]</returns>
        [Route("GetPaginacao")]
        public HttpResponseMessage GetPaginacao(string search, string order, int offset, int limit)
        {
            if (search == null) return Request.CreateResponse(HttpStatusCode.OK, m_EventoBusiness.GetEventoPaginacao(order, offset, limit));

            return Request.CreateResponse(HttpStatusCode.OK, m_EventoBusiness.GetEventoPaginacao(search, order, offset, limit));
        }
    }
}