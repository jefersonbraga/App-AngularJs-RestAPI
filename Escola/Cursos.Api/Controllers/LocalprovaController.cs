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
    /// Public partial Class [LocalprovaService]
    /// </summary>
	[RoutePrefix("services/Localprova")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class LocalprovaController : BaseController, IBaseController<LocalprovaViewModel>
    {
		/// <summary>
        /// Private readonly [LocalprovaService]
        /// </summary>
		private readonly ILocalprovaBusiness m_LocalprovaBusiness;
		/// <summary>
        /// Constructor [Localprova]
        /// </summary>
        public LocalprovaController(ILocalprovaBusiness localprovaBusiness)
        {
            m_LocalprovaBusiness = localprovaBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Localprova]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Localprova]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_LocalprovaBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Localprova]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Localprova]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_LocalprovaBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Localprova]
        /// </summary>
        /// <param name="className">Localprova</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(LocalprovaViewModel localprovaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_LocalprovaBusiness.Add(localprovaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Localprova]
        /// </summary>
        /// <param name="className">Localprova</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(LocalprovaViewModel localprovaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_LocalprovaBusiness.Update(localprovaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(LocalprovaViewModel localprovaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_LocalprovaBusiness.Delete(localprovaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
