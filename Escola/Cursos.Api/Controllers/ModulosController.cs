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
    /// Public partial Class [ModulosService]
    /// </summary>
	[RoutePrefix("services/Modulos")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class ModulosController : BaseController, IBaseController<ModulosViewModel>
    {
		/// <summary>
        /// Private readonly [ModulosService]
        /// </summary>
		private readonly IModulosBusiness m_ModulosBusiness;
		/// <summary>
        /// Constructor [Modulos]
        /// </summary>
        public ModulosController(IModulosBusiness modulosBusiness)
        {
            m_ModulosBusiness = modulosBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Modulos]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Modulos]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_ModulosBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Modulos]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Modulos]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_ModulosBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Modulos]
        /// </summary>
        /// <param name="className">Modulos</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(ModulosViewModel modulosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ModulosBusiness.Add(modulosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Modulos]
        /// </summary>
        /// <param name="className">Modulos</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(ModulosViewModel modulosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ModulosBusiness.Update(modulosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(ModulosViewModel modulosViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ModulosBusiness.Delete(modulosViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
