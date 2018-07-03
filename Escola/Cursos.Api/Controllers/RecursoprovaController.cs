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
    /// Public partial Class [RecursoprovaService]
    /// </summary>
	[RoutePrefix("services/Recursoprova")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class RecursoprovaController : BaseController, IBaseController<RecursoprovaViewModel>
    {
		/// <summary>
        /// Private readonly [RecursoprovaService]
        /// </summary>
		private readonly IRecursoprovaBusiness m_RecursoprovaBusiness;
		/// <summary>
        /// Constructor [Recursoprova]
        /// </summary>
        public RecursoprovaController(IRecursoprovaBusiness recursoprovaBusiness)
        {
            m_RecursoprovaBusiness = recursoprovaBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Recursoprova]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Recursoprova]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_RecursoprovaBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Recursoprova]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Recursoprova]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_RecursoprovaBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Recursoprova]
        /// </summary>
        /// <param name="className">Recursoprova</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(RecursoprovaViewModel recursoprovaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_RecursoprovaBusiness.Add(recursoprovaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Recursoprova]
        /// </summary>
        /// <param name="className">Recursoprova</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(RecursoprovaViewModel recursoprovaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_RecursoprovaBusiness.Update(recursoprovaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(RecursoprovaViewModel recursoprovaViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_RecursoprovaBusiness.Delete(recursoprovaViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
