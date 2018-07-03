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
    /// Public partial Class [InscricaoService]
    /// </summary>
	[RoutePrefix("services/Inscricao")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class InscricaoController : BaseController, IBaseController<InscricaoViewModel>
    {
		/// <summary>
        /// Private readonly [InscricaoService]
        /// </summary>
		private readonly IInscricaoBusiness m_InscricaoBusiness;
		/// <summary>
        /// Constructor [Inscricao]
        /// </summary>
        public InscricaoController(IInscricaoBusiness inscricaoBusiness)
        {
            m_InscricaoBusiness = inscricaoBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Inscricao]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Inscricao]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_InscricaoBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Inscricao]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Inscricao]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_InscricaoBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Inscricao]
        /// </summary>
        /// <param name="className">Inscricao</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(InscricaoViewModel inscricaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_InscricaoBusiness.Add(inscricaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Inscricao]
        /// </summary>
        /// <param name="className">Inscricao</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(InscricaoViewModel inscricaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_InscricaoBusiness.Update(inscricaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(InscricaoViewModel inscricaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_InscricaoBusiness.Delete(inscricaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
