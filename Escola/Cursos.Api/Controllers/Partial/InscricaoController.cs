using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Cursos.Api.Controllers
{
    public partial class InscricaoController
    {
        [Route("GetByClientId/{id}")]
        public HttpResponseMessage GetByClientId(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_InscricaoBusiness.GetByClientId(id));
        }


        [Route("GetTopInscricoes")]
        public HttpResponseMessage GetTopInscricoes()
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_InscricaoBusiness.GetTopInscricoes());
        }

        [Route("GetPaginacao")]
        public HttpResponseMessage GetPaginacao(string search, string order, int offset, int limit)
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_InscricaoBusiness.GetInscricaoPaginacao(search,order,offset,limit));
        }

        [Route("GetPaginacao")]
        public HttpResponseMessage GetPaginacao(string order, int offset, int limit)
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_InscricaoBusiness.GetInscricaoPaginacao(order, offset, limit));
        }
    }
}