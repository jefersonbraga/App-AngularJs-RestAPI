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
    /// Public partial Class [QuestoescorrecaoService]
    /// </summary>
	[RoutePrefix("services/Questoescorrecao")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class QuestoescorrecaoController : BaseController, IBaseController<QuestoescorrecaoViewModel>
    {
		/// <summary>
        /// Private readonly [QuestoescorrecaoService]
        /// </summary>
		private readonly IQuestoescorrecaoBusiness m_QuestoescorrecaoBusiness;
		/// <summary>
        /// Constructor [Questoescorrecao]
        /// </summary>
        public QuestoescorrecaoController(IQuestoescorrecaoBusiness questoescorrecaoBusiness)
        {
            m_QuestoescorrecaoBusiness = questoescorrecaoBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Questoescorrecao]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Questoescorrecao]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_QuestoescorrecaoBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Questoescorrecao]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Questoescorrecao]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_QuestoescorrecaoBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Questoescorrecao]
        /// </summary>
        /// <param name="className">Questoescorrecao</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(QuestoescorrecaoViewModel questoescorrecaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_QuestoescorrecaoBusiness.Add(questoescorrecaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Questoescorrecao]
        /// </summary>
        /// <param name="className">Questoescorrecao</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(QuestoescorrecaoViewModel questoescorrecaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_QuestoescorrecaoBusiness.Update(questoescorrecaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(QuestoescorrecaoViewModel questoescorrecaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_QuestoescorrecaoBusiness.Delete(questoescorrecaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
