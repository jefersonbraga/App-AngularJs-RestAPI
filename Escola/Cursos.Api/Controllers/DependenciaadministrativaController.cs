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
    /// Public partial Class [DependenciaadministrativaService]
    /// </summary>
	[RoutePrefix("services/Dependenciaadministrativa")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class DependenciaadministrativaController : BaseController, IBaseController<DependenciaadministrativaViewModel>
    {
		/// <summary>
        /// Private readonly [DependenciaadministrativaService]
        /// </summary>
		private readonly IDependenciaadministrativaBusiness m_DependenciaadministrativaBusiness;
		/// <summary>
        /// Constructor [Dependenciaadministrativa]
        /// </summary>
        public DependenciaadministrativaController(IDependenciaadministrativaBusiness dependenciaadministrativaBusiness)
        {
            m_DependenciaadministrativaBusiness = dependenciaadministrativaBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Dependenciaadministrativa]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Dependenciaadministrativa]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_DependenciaadministrativaBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Dependenciaadministrativa]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Dependenciaadministrativa]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_DependenciaadministrativaBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Dependenciaadministrativa]
        /// </summary>
        /// <param name="className">Dependenciaadministrativa</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(DependenciaadministrativaViewModel dependenciaadministrativaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_DependenciaadministrativaBusiness.Add(dependenciaadministrativaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Dependenciaadministrativa]
        /// </summary>
        /// <param name="className">Dependenciaadministrativa</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(DependenciaadministrativaViewModel dependenciaadministrativaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_DependenciaadministrativaBusiness.Update(dependenciaadministrativaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(DependenciaadministrativaViewModel dependenciaadministrativaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_DependenciaadministrativaBusiness.Delete(dependenciaadministrativaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
