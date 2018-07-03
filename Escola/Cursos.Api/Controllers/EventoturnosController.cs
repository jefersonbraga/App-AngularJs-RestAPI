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
    /// Public partial Class [EventoturnosService]
    /// </summary>
	[RoutePrefix("services/Eventoturnos")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class EventoturnosController : BaseController, IBaseController<EventoturnosViewModel>
    {
		/// <summary>
        /// Private readonly [EventoturnosService]
        /// </summary>
		private readonly IEventoturnosBusiness m_EventoturnosBusiness;
		/// <summary>
        /// Constructor [Eventoturnos]
        /// </summary>
        public EventoturnosController(IEventoturnosBusiness eventoturnosBusiness)
        {
            m_EventoturnosBusiness = eventoturnosBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Eventoturnos]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Eventoturnos]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_EventoturnosBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Eventoturnos]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Eventoturnos]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_EventoturnosBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Eventoturnos]
        /// </summary>
        /// <param name="className">Eventoturnos</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(EventoturnosViewModel eventoturnosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EventoturnosBusiness.Add(eventoturnosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Eventoturnos]
        /// </summary>
        /// <param name="className">Eventoturnos</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(EventoturnosViewModel eventoturnosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EventoturnosBusiness.Update(eventoturnosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(EventoturnosViewModel eventoturnosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EventoturnosBusiness.Delete(eventoturnosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
