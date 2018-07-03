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
    /// Public partial Class [EventodatasService]
    /// </summary>
	[RoutePrefix("services/Eventodatas")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class EventodatasController : BaseController, IBaseController<EventodatasViewModel>
    {
		/// <summary>
        /// Private readonly [EventodatasService]
        /// </summary>
		private readonly IEventodatasBusiness m_EventodatasBusiness;
		/// <summary>
        /// Constructor [Eventodatas]
        /// </summary>
        public EventodatasController(IEventodatasBusiness eventodatasBusiness)
        {
            m_EventodatasBusiness = eventodatasBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Eventodatas]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Eventodatas]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_EventodatasBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Eventodatas]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Eventodatas]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_EventodatasBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Eventodatas]
        /// </summary>
        /// <param name="className">Eventodatas</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(EventodatasViewModel eventodatasViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EventodatasBusiness.Add(eventodatasViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Eventodatas]
        /// </summary>
        /// <param name="className">Eventodatas</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(EventodatasViewModel eventodatasViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EventodatasBusiness.Update(eventodatasViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(EventodatasViewModel eventodatasViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EventodatasBusiness.Delete(eventodatasViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
