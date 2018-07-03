///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/12/2017 2:46:24 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using System.Collections.Generic;
using Cursos.ViewModel;
using Cursos.Api.Controllers.Base;
using Cursos.Business.Interfaces;
namespace Cursos.Api.Controllers
{
	/// <summary>
    /// Public partial Class [SituacaoeventoService]
    /// </summary>
	[RoutePrefix("services/Situacaoevento")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class SituacaoeventoController : BaseController, IBaseController<SituacaoeventoViewModel>
    {
		/// <summary>
        /// Private readonly [SituacaoeventoService]
        /// </summary>
		private readonly ISituacaoeventoBusiness m_SituacaoeventoBusiness;
		/// <summary>
        /// Constructor [Situacaoevento]
        /// </summary>
        public SituacaoeventoController(ISituacaoeventoBusiness situacaoeventoBusiness)
        {
            m_SituacaoeventoBusiness = situacaoeventoBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Situacaoevento]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Situacaoevento]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_SituacaoeventoBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Situacaoevento]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Situacaoevento]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_SituacaoeventoBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Situacaoevento]
        /// </summary>
        /// <param name="className">Situacaoevento</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(SituacaoeventoViewModel situacaoeventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_SituacaoeventoBusiness.Add(situacaoeventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Situacaoevento]
        /// </summary>
        /// <param name="className">Situacaoevento</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(SituacaoeventoViewModel situacaoeventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_SituacaoeventoBusiness.Update(situacaoeventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(SituacaoeventoViewModel situacaoeventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_SituacaoeventoBusiness.Delete(situacaoeventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
