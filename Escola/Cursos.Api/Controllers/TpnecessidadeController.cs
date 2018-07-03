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
    /// Public partial Class [TpnecessidadeService]
    /// </summary>
	[RoutePrefix("services/Tpnecessidade")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class TpnecessidadeController : BaseController, IBaseController<TpnecessidadeViewModel>
    {
		/// <summary>
        /// Private readonly [TpnecessidadeService]
        /// </summary>
		private readonly ITpnecessidadeBusiness m_TpnecessidadeBusiness;
		/// <summary>
        /// Constructor [Tpnecessidade]
        /// </summary>
        public TpnecessidadeController(ITpnecessidadeBusiness tpnecessidadeBusiness)
        {
            m_TpnecessidadeBusiness = tpnecessidadeBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Tpnecessidade]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Tpnecessidade]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_TpnecessidadeBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Tpnecessidade]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Tpnecessidade]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_TpnecessidadeBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Tpnecessidade]
        /// </summary>
        /// <param name="className">Tpnecessidade</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(TpnecessidadeViewModel tpnecessidadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_TpnecessidadeBusiness.Add(tpnecessidadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Tpnecessidade]
        /// </summary>
        /// <param name="className">Tpnecessidade</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(TpnecessidadeViewModel tpnecessidadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_TpnecessidadeBusiness.Update(tpnecessidadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(TpnecessidadeViewModel tpnecessidadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_TpnecessidadeBusiness.Delete(tpnecessidadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
