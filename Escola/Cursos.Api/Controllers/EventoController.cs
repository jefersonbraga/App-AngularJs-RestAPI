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
    /// Public partial Class [EventoService]
    /// </summary>
	[RoutePrefix("services/Evento")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class EventoController : BaseController, IBaseController<EventoViewModel>
    {
		/// <summary>
        /// Private readonly [EventoService]
        /// </summary>
		private readonly IEventoBusiness m_EventoBusiness;
		/// <summary>
        /// Constructor [Evento]
        /// </summary>
        public EventoController(IEventoBusiness eventoBusiness)
        {
            m_EventoBusiness = eventoBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Evento]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Evento]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_EventoBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Evento]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Evento]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_EventoBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Evento]
        /// </summary>
        /// <param name="className">Evento</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(EventoViewModel eventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EventoBusiness.Add(eventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Evento]
        /// </summary>
        /// <param name="className">Evento</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(EventoViewModel eventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EventoBusiness.Update(eventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(EventoViewModel eventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EventoBusiness.Delete(eventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
