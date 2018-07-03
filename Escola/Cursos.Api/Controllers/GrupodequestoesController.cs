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
    /// Public partial Class [GrupodequestoesService]
    /// </summary>
	[RoutePrefix("services/Grupodequestoes")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class GrupodequestoesController : BaseController, IBaseController<GrupodequestoesViewModel>
    {
		/// <summary>
        /// Private readonly [GrupodequestoesService]
        /// </summary>
		private readonly IGrupodequestoesBusiness m_GrupodequestoesBusiness;
		/// <summary>
        /// Constructor [Grupodequestoes]
        /// </summary>
        public GrupodequestoesController(IGrupodequestoesBusiness grupodequestoesBusiness)
        {
            m_GrupodequestoesBusiness = grupodequestoesBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Grupodequestoes]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Grupodequestoes]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_GrupodequestoesBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Grupodequestoes]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Grupodequestoes]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_GrupodequestoesBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Grupodequestoes]
        /// </summary>
        /// <param name="className">Grupodequestoes</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(GrupodequestoesViewModel grupodequestoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_GrupodequestoesBusiness.Add(grupodequestoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Grupodequestoes]
        /// </summary>
        /// <param name="className">Grupodequestoes</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(GrupodequestoesViewModel grupodequestoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_GrupodequestoesBusiness.Update(grupodequestoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(GrupodequestoesViewModel grupodequestoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_GrupodequestoesBusiness.Delete(grupodequestoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
