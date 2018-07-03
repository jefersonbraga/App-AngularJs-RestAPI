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
    /// Public partial Class [OrgaoemissorService]
    /// </summary>
	[RoutePrefix("services/Orgaoemissor")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class OrgaoemissorController : BaseController, IBaseController<OrgaoemissorViewModel>
    {
		/// <summary>
        /// Private readonly [OrgaoemissorService]
        /// </summary>
		private readonly IOrgaoemissorBusiness m_OrgaoemissorBusiness;
		/// <summary>
        /// Constructor [Orgaoemissor]
        /// </summary>
        public OrgaoemissorController(IOrgaoemissorBusiness orgaoemissorBusiness)
        {
            m_OrgaoemissorBusiness = orgaoemissorBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Orgaoemissor]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Orgaoemissor]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_OrgaoemissorBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Orgaoemissor]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Orgaoemissor]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_OrgaoemissorBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Orgaoemissor]
        /// </summary>
        /// <param name="className">Orgaoemissor</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(OrgaoemissorViewModel orgaoemissorViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_OrgaoemissorBusiness.Add(orgaoemissorViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Orgaoemissor]
        /// </summary>
        /// <param name="className">Orgaoemissor</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(OrgaoemissorViewModel orgaoemissorViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_OrgaoemissorBusiness.Update(orgaoemissorViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(OrgaoemissorViewModel orgaoemissorViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_OrgaoemissorBusiness.Delete(orgaoemissorViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
