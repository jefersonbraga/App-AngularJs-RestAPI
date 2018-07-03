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
    /// Public partial Class [OrgaosService]
    /// </summary>
	[RoutePrefix("services/Orgaos")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class OrgaosController : BaseController, IBaseController<OrgaosViewModel>
    {
		/// <summary>
        /// Private readonly [OrgaosService]
        /// </summary>
		private readonly IOrgaosBusiness m_OrgaosBusiness;
		/// <summary>
        /// Constructor [Orgaos]
        /// </summary>
        public OrgaosController(IOrgaosBusiness orgaosBusiness)
        {
            m_OrgaosBusiness = orgaosBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Orgaos]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Orgaos]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_OrgaosBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Orgaos]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Orgaos]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_OrgaosBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Orgaos]
        /// </summary>
        /// <param name="className">Orgaos</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(OrgaosViewModel orgaosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_OrgaosBusiness.Add(orgaosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Orgaos]
        /// </summary>
        /// <param name="className">Orgaos</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(OrgaosViewModel orgaosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_OrgaosBusiness.Update(orgaosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(OrgaosViewModel orgaosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_OrgaosBusiness.Delete(orgaosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
