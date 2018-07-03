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
    /// Public partial Class [DivulgacaoService]
    /// </summary>
	[RoutePrefix("services/Divulgacao")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class DivulgacaoController : BaseController, IBaseController<DivulgacaoViewModel>
    {
		/// <summary>
        /// Private readonly [DivulgacaoService]
        /// </summary>
		private readonly IDivulgacaoBusiness m_DivulgacaoBusiness;
		/// <summary>
        /// Constructor [Divulgacao]
        /// </summary>
        public DivulgacaoController(IDivulgacaoBusiness divulgacaoBusiness)
        {
            m_DivulgacaoBusiness = divulgacaoBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Divulgacao]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Divulgacao]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_DivulgacaoBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Divulgacao]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Divulgacao]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_DivulgacaoBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Divulgacao]
        /// </summary>
        /// <param name="className">Divulgacao</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(DivulgacaoViewModel divulgacaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_DivulgacaoBusiness.Add(divulgacaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Divulgacao]
        /// </summary>
        /// <param name="className">Divulgacao</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(DivulgacaoViewModel divulgacaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_DivulgacaoBusiness.Update(divulgacaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(DivulgacaoViewModel divulgacaoViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_DivulgacaoBusiness.Delete(divulgacaoViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
