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
    /// Public partial Class [ProvaquestoesService]
    /// </summary>
	[RoutePrefix("services/Provaquestoes")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class ProvaquestoesController : BaseController, IBaseController<ProvaquestoesViewModel>
    {
		/// <summary>
        /// Private readonly [ProvaquestoesService]
        /// </summary>
		private readonly IProvaquestoesBusiness m_ProvaquestoesBusiness;
		/// <summary>
        /// Constructor [Provaquestoes]
        /// </summary>
        public ProvaquestoesController(IProvaquestoesBusiness provaquestoesBusiness)
        {
            m_ProvaquestoesBusiness = provaquestoesBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Provaquestoes]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Provaquestoes]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_ProvaquestoesBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Provaquestoes]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Provaquestoes]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_ProvaquestoesBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Provaquestoes]
        /// </summary>
        /// <param name="className">Provaquestoes</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(ProvaquestoesViewModel provaquestoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ProvaquestoesBusiness.Add(provaquestoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Provaquestoes]
        /// </summary>
        /// <param name="className">Provaquestoes</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(ProvaquestoesViewModel provaquestoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ProvaquestoesBusiness.Update(provaquestoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(ProvaquestoesViewModel provaquestoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ProvaquestoesBusiness.Delete(provaquestoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
