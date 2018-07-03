using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Api.Controllers
{
    public partial class ClienteController
    {
        private readonly IReportingBusiness m_ReportingBusiness;

        public ClienteController(IClienteBusiness clienteBusiness, IReportingBusiness reportingBusiness)
        {
            m_ClienteBusiness = clienteBusiness;
            m_ReportingBusiness = reportingBusiness;
        }

        [Route("getClientes/{avaliacaoid}")]
        public HttpResponseMessage GetClientes(int avaliacaoid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.GetClientes(avaliacaoid));
        }

        [Route("getByCpf/{cpf}")]
        public HttpResponseMessage GetByCpf(string cpf)
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.GetByCpf(cpf));
        }

        /// <summary>
        /// Method GetAll() [m_Cliente]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Cliente]</returns>
        [Route("GetPaginacao")]
        public HttpResponseMessage GetPaginacao(string order, int offset, int limit)
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.GetClientePaginacao(order, offset, limit));
        }

        /// <summary>
        /// Method GetAll() [m_Cliente]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Cliente]</returns>
        [Route("GetFilter")]
        public HttpResponseMessage GetFilter(string filter, string order, int offset, int limit)
        {
            try
            {
                var parameter = JsonConvert.DeserializeObject<FilterClientes>(filter);
                if (parameter.Dtaniversario == DateTime.MinValue)
                    parameter.Dtaniversario = null;
                return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.GetClientePaginacao(parameter, order, offset, limit));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method GetAll() [m_Cliente]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Cliente]</returns>
        [Route("GetPaginacao")]
        public HttpResponseMessage GetPaginacao(string search, string order, int offset, int limit, string filter)
        {
            var parameter = JsonConvert.DeserializeObject<FilterClientes>(filter);

            return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.GetClientePaginacao(parameter, order, offset, limit));
        }

        [Route("gettopclientes")]
        public HttpResponseMessage GetTopClientes()
        {
            return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.GetTopClientes());
        }

        [Route("getreportclientes"), HttpGet]
        public HttpResponseMessage GetReportClientes(string filter, string typeFile)
        {
            var parameter = JsonConvert.DeserializeObject<FilterClientes>(filter);
            string extensao = "xlsx";

            if (typeFile == "pdf")
                extensao = "pdf";
            else if (typeFile == "word")
                extensao = "docx";

            var fileName = string.Format("RelatorioClientes-{0}.{1}", DateTime.Now.ToString("ddMMyyyhhmmss"), extensao);

            var wbReport = m_ReportingBusiness.ReportCliente("jeferson", fileName, parameter);
            

            if (wbReport == null) Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sem registros");
            using (MemoryStream streamWorksheet = wbReport)
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(streamWorksheet.ToArray())
                };
              
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
                if (typeFile == "pdf")
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                else if (typeFile == "excel")
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                else if (typeFile == "word")
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/msword"); 
                  //  result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                result.Content.Headers.Add("Filename", fileName);
                result.Content.Headers.Add("Access-Control-Expose-Headers", "Filename");
                return result;
            }
        }
    }
}