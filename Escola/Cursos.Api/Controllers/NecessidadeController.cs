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
    /// Public partial Class [NecessidadeService]
    /// </summary>
	[RoutePrefix("services/Necessidade")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class NecessidadeController : BaseController, IBaseController<NecessidadeViewModel>
    {
		/// <summary>
        /// Private readonly [NecessidadeService]
        /// </summary>
		private readonly INecessidadeBusiness m_NecessidadeBusiness;
		/// <summary>
        /// Constructor [Necessidade]
        /// </summary>
        public NecessidadeController(INecessidadeBusiness necessidadeBusiness)
        {
            m_NecessidadeBusiness = necessidadeBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Necessidade]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Necessidade]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_NecessidadeBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Necessidade]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Necessidade]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_NecessidadeBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Necessidade]
        /// </summary>
        /// <param name="className">Necessidade</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(NecessidadeViewModel necessidadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_NecessidadeBusiness.Add(necessidadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Necessidade]
        /// </summary>
        /// <param name="className">Necessidade</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(NecessidadeViewModel necessidadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_NecessidadeBusiness.Update(necessidadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(NecessidadeViewModel necessidadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_NecessidadeBusiness.Delete(necessidadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
