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
    /// Public partial Class [AvaliacaoobservacaoService]
    /// </summary>
	[RoutePrefix("services/Avaliacaoobservacao")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class AvaliacaoobservacaoController : BaseController, IBaseController<AvaliacaoobservacaoViewModel>
    {
		/// <summary>
        /// Private readonly [AvaliacaoobservacaoService]
        /// </summary>
		private readonly IAvaliacaoobservacaoBusiness m_AvaliacaoobservacaoBusiness;
		/// <summary>
        /// Constructor [Avaliacaoobservacao]
        /// </summary>
        public AvaliacaoobservacaoController(IAvaliacaoobservacaoBusiness avaliacaoobservacaoBusiness)
        {
            m_AvaliacaoobservacaoBusiness = avaliacaoobservacaoBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Avaliacaoobservacao]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Avaliacaoobservacao]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoobservacaoBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Avaliacaoobservacao]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Avaliacaoobservacao]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoobservacaoBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Avaliacaoobservacao]
        /// </summary>
        /// <param name="className">Avaliacaoobservacao</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(AvaliacaoobservacaoViewModel avaliacaoobservacaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoobservacaoBusiness.Add(avaliacaoobservacaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Avaliacaoobservacao]
        /// </summary>
        /// <param name="className">Avaliacaoobservacao</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(AvaliacaoobservacaoViewModel avaliacaoobservacaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoobservacaoBusiness.Update(avaliacaoobservacaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(AvaliacaoobservacaoViewModel avaliacaoobservacaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoobservacaoBusiness.Delete(avaliacaoobservacaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
