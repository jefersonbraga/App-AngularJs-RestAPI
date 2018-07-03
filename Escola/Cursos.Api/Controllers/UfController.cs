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
    /// Public partial Class [UfService]
    /// </summary>
	[RoutePrefix("services/Uf")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class UfController : BaseController, IBaseController<UfViewModel>
    {
		/// <summary>
        /// Private readonly [UfService]
        /// </summary>
		private readonly IUfBusiness m_UfBusiness;
		/// <summary>
        /// Constructor [Uf]
        /// </summary>
        public UfController(IUfBusiness ufBusiness)
        {
            m_UfBusiness = ufBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Uf]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Uf]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_UfBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Uf]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Uf]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_UfBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Uf]
        /// </summary>
        /// <param name="className">Uf</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(UfViewModel ufViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_UfBusiness.Add(ufViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Uf]
        /// </summary>
        /// <param name="className">Uf</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(UfViewModel ufViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_UfBusiness.Update(ufViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(UfViewModel ufViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_UfBusiness.Delete(ufViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
