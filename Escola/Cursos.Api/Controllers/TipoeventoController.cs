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
    /// Public partial Class [TipoeventoService]
    /// </summary>
	[RoutePrefix("services/Tipoevento")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class TipoeventoController : BaseController, IBaseController<TipoeventoViewModel>
    {
		/// <summary>
        /// Private readonly [TipoeventoService]
        /// </summary>
		private readonly ITipoeventoBusiness m_TipoeventoBusiness;
		/// <summary>
        /// Constructor [Tipoevento]
        /// </summary>
        public TipoeventoController(ITipoeventoBusiness tipoeventoBusiness)
        {
            m_TipoeventoBusiness = tipoeventoBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Tipoevento]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Tipoevento]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_TipoeventoBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Tipoevento]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Tipoevento]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_TipoeventoBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Tipoevento]
        /// </summary>
        /// <param name="className">Tipoevento</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(TipoeventoViewModel tipoeventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_TipoeventoBusiness.Add(tipoeventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Tipoevento]
        /// </summary>
        /// <param name="className">Tipoevento</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(TipoeventoViewModel tipoeventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_TipoeventoBusiness.Update(tipoeventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(TipoeventoViewModel tipoeventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_TipoeventoBusiness.Delete(tipoeventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
