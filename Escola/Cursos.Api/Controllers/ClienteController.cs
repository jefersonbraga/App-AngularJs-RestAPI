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
    /// Public partial Class [ClienteService]
    /// </summary>
	[RoutePrefix("services/Cliente")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class ClienteController : BaseController, IBaseController<ClienteViewModel>
    {
		/// <summary>
        /// Private readonly [ClienteService]
        /// </summary>
		private readonly IClienteBusiness m_ClienteBusiness;
		/// <summary>
        /// Constructor [Cliente]
        /// </summary>
        public ClienteController(IClienteBusiness clienteBusiness)
        {
            m_ClienteBusiness = clienteBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Cliente]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Cliente]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Cliente]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Cliente]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Cliente]
        /// </summary>
        /// <param name="className">Cliente</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(ClienteViewModel clienteViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.Add(clienteViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Cliente]
        /// </summary>
        /// <param name="className">Cliente</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(ClienteViewModel clienteViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.Update(clienteViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(ClienteViewModel clienteViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ClienteBusiness.Delete(clienteViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
