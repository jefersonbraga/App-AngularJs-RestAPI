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
    /// Public partial Class [ControlenecessidadeService]
    /// </summary>
	[RoutePrefix("services/Controlenecessidade")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class ControlenecessidadeController : BaseController, IBaseController<ControlenecessidadeViewModel>
    {
		/// <summary>
        /// Private readonly [ControlenecessidadeService]
        /// </summary>
		private readonly IControlenecessidadeBusiness m_ControlenecessidadeBusiness;
		/// <summary>
        /// Constructor [Controlenecessidade]
        /// </summary>
        public ControlenecessidadeController(IControlenecessidadeBusiness controlenecessidadeBusiness)
        {
            m_ControlenecessidadeBusiness = controlenecessidadeBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Controlenecessidade]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Controlenecessidade]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_ControlenecessidadeBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Controlenecessidade]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Controlenecessidade]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_ControlenecessidadeBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Controlenecessidade]
        /// </summary>
        /// <param name="className">Controlenecessidade</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(ControlenecessidadeViewModel controlenecessidadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ControlenecessidadeBusiness.Add(controlenecessidadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Controlenecessidade]
        /// </summary>
        /// <param name="className">Controlenecessidade</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(ControlenecessidadeViewModel controlenecessidadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ControlenecessidadeBusiness.Update(controlenecessidadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(ControlenecessidadeViewModel controlenecessidadeViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ControlenecessidadeBusiness.Delete(controlenecessidadeViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
