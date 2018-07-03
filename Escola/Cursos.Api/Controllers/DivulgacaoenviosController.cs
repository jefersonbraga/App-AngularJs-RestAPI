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
    /// Public partial Class [DivulgacaoenviosService]
    /// </summary>
	[RoutePrefix("services/Divulgacaoenvios")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class DivulgacaoenviosController : BaseController, IBaseController<DivulgacaoenviosViewModel>
    {
		/// <summary>
        /// Private readonly [DivulgacaoenviosService]
        /// </summary>
		private readonly IDivulgacaoenviosBusiness m_DivulgacaoenviosBusiness;
		/// <summary>
        /// Constructor [Divulgacaoenvios]
        /// </summary>
        public DivulgacaoenviosController(IDivulgacaoenviosBusiness divulgacaoenviosBusiness)
        {
            m_DivulgacaoenviosBusiness = divulgacaoenviosBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Divulgacaoenvios]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Divulgacaoenvios]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_DivulgacaoenviosBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Divulgacaoenvios]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Divulgacaoenvios]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_DivulgacaoenviosBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Divulgacaoenvios]
        /// </summary>
        /// <param name="className">Divulgacaoenvios</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(DivulgacaoenviosViewModel divulgacaoenviosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_DivulgacaoenviosBusiness.Add(divulgacaoenviosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Divulgacaoenvios]
        /// </summary>
        /// <param name="className">Divulgacaoenvios</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(DivulgacaoenviosViewModel divulgacaoenviosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_DivulgacaoenviosBusiness.Update(divulgacaoenviosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(DivulgacaoenviosViewModel divulgacaoenviosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_DivulgacaoenviosBusiness.Delete(divulgacaoenviosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
