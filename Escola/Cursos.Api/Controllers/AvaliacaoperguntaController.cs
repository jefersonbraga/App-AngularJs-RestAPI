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
    /// Public partial Class [AvaliacaoperguntaService]
    /// </summary>
	[RoutePrefix("services/Avaliacaopergunta")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class AvaliacaoperguntaController : BaseController, IBaseController<AvaliacaoperguntaViewModel>
    {
		/// <summary>
        /// Private readonly [AvaliacaoperguntaService]
        /// </summary>
		private readonly IAvaliacaoperguntaBusiness m_AvaliacaoperguntaBusiness;
		/// <summary>
        /// Constructor [Avaliacaopergunta]
        /// </summary>
        public AvaliacaoperguntaController(IAvaliacaoperguntaBusiness avaliacaoperguntaBusiness)
        {
            m_AvaliacaoperguntaBusiness = avaliacaoperguntaBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Avaliacaopergunta]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Avaliacaopergunta]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoperguntaBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Avaliacaopergunta]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Avaliacaopergunta]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoperguntaBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Avaliacaopergunta]
        /// </summary>
        /// <param name="className">Avaliacaopergunta</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(AvaliacaoperguntaViewModel avaliacaoperguntaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoperguntaBusiness.Add(avaliacaoperguntaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Avaliacaopergunta]
        /// </summary>
        /// <param name="className">Avaliacaopergunta</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(AvaliacaoperguntaViewModel avaliacaoperguntaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoperguntaBusiness.Update(avaliacaoperguntaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(AvaliacaoperguntaViewModel avaliacaoperguntaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AvaliacaoperguntaBusiness.Delete(avaliacaoperguntaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
