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
    /// Public partial Class [TemaService]
    /// </summary>
	[RoutePrefix("services/Tema")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class TemaController : BaseController, IBaseController<TemaViewModel>
    {
		/// <summary>
        /// Private readonly [TemaService]
        /// </summary>
		private readonly ITemaBusiness m_TemaBusiness;
		/// <summary>
        /// Constructor [Tema]
        /// </summary>
        public TemaController(ITemaBusiness temaBusiness)
        {
            m_TemaBusiness = temaBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Tema]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Tema]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_TemaBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Tema]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Tema]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_TemaBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Tema]
        /// </summary>
        /// <param name="className">Tema</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(TemaViewModel temaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_TemaBusiness.Add(temaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Tema]
        /// </summary>
        /// <param name="className">Tema</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(TemaViewModel temaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_TemaBusiness.Update(temaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(TemaViewModel temaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_TemaBusiness.Delete(temaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
