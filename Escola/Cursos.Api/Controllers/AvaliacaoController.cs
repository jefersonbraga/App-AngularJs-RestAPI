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
    /// Public partial Class [AvaliacaoService]
    /// </summary>
	[RoutePrefix("services/Avaliacao")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class AvaliacaoController : BaseController, IBaseController<AvaliacaoViewModel>
    {
		/// <summary>
        /// Private readonly [AvaliacaoService]
        /// </summary>
		private readonly IAvaliacaoBusiness m_AvaliacaoBusiness;
		/// <summary>
        /// Constructor [Avaliacao]
        /// </summary>
        public AvaliacaoController(IAvaliacaoBusiness avaliacaoBusiness)
        {
            m_AvaliacaoBusiness = avaliacaoBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Avaliacao]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Avaliacao]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoBusiness.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
			
        }
		/// <summary>
        /// Method GetById [m_Avaliacao]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Avaliacao]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Avaliacao]
        /// </summary>
        /// <param name="className">Avaliacao</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(AvaliacaoViewModel avaliacaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoBusiness.Add(avaliacaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Avaliacao]
        /// </summary>
        /// <param name="className">Avaliacao</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update([FromBody]AvaliacaoViewModel avaliacaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoBusiness.Update(avaliacaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(AvaliacaoViewModel avaliacaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoBusiness.Delete(avaliacaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
