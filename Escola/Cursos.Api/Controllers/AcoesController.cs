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
    /// Public partial Class [AcoesService]
    /// </summary>
	[RoutePrefix("services/Acoes")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class AcoesController : BaseController, IBaseController<AcoesViewModel>
    {
		/// <summary>
        /// Private readonly [AcoesService]
        /// </summary>
		private readonly IAcoesBusiness m_AcoesBusiness;
		/// <summary>
        /// Constructor [Acoes]
        /// </summary>
        public AcoesController(IAcoesBusiness acoesBusiness)
        {
            m_AcoesBusiness = acoesBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Acoes]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Acoes]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_AcoesBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Acoes]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Acoes]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_AcoesBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Acoes]
        /// </summary>
        /// <param name="className">Acoes</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(AcoesViewModel acoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AcoesBusiness.Add(acoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Acoes]
        /// </summary>
        /// <param name="className">Acoes</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(AcoesViewModel acoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AcoesBusiness.Update(acoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(AcoesViewModel acoesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_AcoesBusiness.Delete(acoesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
