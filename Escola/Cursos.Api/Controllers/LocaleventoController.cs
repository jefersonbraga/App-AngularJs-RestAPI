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
    /// Public partial Class [LocaleventoService]
    /// </summary>
	[RoutePrefix("services/Localevento")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class LocaleventoController : BaseController, IBaseController<LocaleventoViewModel>
    {
		/// <summary>
        /// Private readonly [LocaleventoService]
        /// </summary>
		private readonly ILocaleventoBusiness m_LocaleventoBusiness;
		/// <summary>
        /// Constructor [Localevento]
        /// </summary>
        public LocaleventoController(ILocaleventoBusiness localeventoBusiness)
        {
            m_LocaleventoBusiness = localeventoBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Localevento]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Localevento]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_LocaleventoBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Localevento]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Localevento]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_LocaleventoBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Localevento]
        /// </summary>
        /// <param name="className">Localevento</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(LocaleventoViewModel localeventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_LocaleventoBusiness.Add(localeventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Localevento]
        /// </summary>
        /// <param name="className">Localevento</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(LocaleventoViewModel localeventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_LocaleventoBusiness.Update(localeventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(LocaleventoViewModel localeventoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_LocaleventoBusiness.Delete(localeventoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
