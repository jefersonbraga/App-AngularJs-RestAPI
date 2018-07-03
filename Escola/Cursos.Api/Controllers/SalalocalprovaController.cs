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
    /// Public partial Class [SalalocalprovaService]
    /// </summary>
	[RoutePrefix("services/Salalocalprova")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class SalalocalprovaController : BaseController, IBaseController<SalalocalprovaViewModel>
    {
		/// <summary>
        /// Private readonly [SalalocalprovaService]
        /// </summary>
		private readonly ISalalocalprovaBusiness m_SalalocalprovaBusiness;
		/// <summary>
        /// Constructor [Salalocalprova]
        /// </summary>
        public SalalocalprovaController(ISalalocalprovaBusiness salalocalprovaBusiness)
        {
            m_SalalocalprovaBusiness = salalocalprovaBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Salalocalprova]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Salalocalprova]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_SalalocalprovaBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Salalocalprova]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Salalocalprova]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_SalalocalprovaBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Salalocalprova]
        /// </summary>
        /// <param name="className">Salalocalprova</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(SalalocalprovaViewModel salalocalprovaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_SalalocalprovaBusiness.Add(salalocalprovaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Salalocalprova]
        /// </summary>
        /// <param name="className">Salalocalprova</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(SalalocalprovaViewModel salalocalprovaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_SalalocalprovaBusiness.Update(salalocalprovaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(SalalocalprovaViewModel salalocalprovaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_SalalocalprovaBusiness.Delete(salalocalprovaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
