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
    /// Public partial Class [EscolaridadeService]
    /// </summary>
	[RoutePrefix("services/Escolaridade")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class EscolaridadeController : BaseController, IBaseController<EscolaridadeViewModel>
    {
		/// <summary>
        /// Private readonly [EscolaridadeService]
        /// </summary>
		private readonly IEscolaridadeBusiness m_EscolaridadeBusiness;
		/// <summary>
        /// Constructor [Escolaridade]
        /// </summary>
        public EscolaridadeController(IEscolaridadeBusiness escolaridadeBusiness)
        {
            m_EscolaridadeBusiness = escolaridadeBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Escolaridade]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Escolaridade]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_EscolaridadeBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Escolaridade]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Escolaridade]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_EscolaridadeBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Escolaridade]
        /// </summary>
        /// <param name="className">Escolaridade</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(EscolaridadeViewModel escolaridadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EscolaridadeBusiness.Add(escolaridadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Escolaridade]
        /// </summary>
        /// <param name="className">Escolaridade</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(EscolaridadeViewModel escolaridadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EscolaridadeBusiness.Update(escolaridadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(EscolaridadeViewModel escolaridadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_EscolaridadeBusiness.Delete(escolaridadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
