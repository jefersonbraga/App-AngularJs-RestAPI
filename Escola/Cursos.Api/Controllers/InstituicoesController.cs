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
    /// Public partial Class [InstituicoesService]
    /// </summary>
	[RoutePrefix("services/Instituicoes")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class InstituicoesController : BaseController, IBaseController<InstituicoesViewModel>
    {
		/// <summary>
        /// Private readonly [InstituicoesService]
        /// </summary>
		private readonly IInstituicoesBusiness m_InstituicoesBusiness;
		/// <summary>
        /// Constructor [Instituicoes]
        /// </summary>
        public InstituicoesController(IInstituicoesBusiness instituicoesBusiness)
        {
            m_InstituicoesBusiness = instituicoesBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Instituicoes]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Instituicoes]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_InstituicoesBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Instituicoes]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Instituicoes]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_InstituicoesBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Instituicoes]
        /// </summary>
        /// <param name="className">Instituicoes</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(InstituicoesViewModel instituicoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_InstituicoesBusiness.Add(instituicoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Instituicoes]
        /// </summary>
        /// <param name="className">Instituicoes</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(InstituicoesViewModel instituicoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_InstituicoesBusiness.Update(instituicoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(InstituicoesViewModel instituicoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_InstituicoesBusiness.Delete(instituicoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
