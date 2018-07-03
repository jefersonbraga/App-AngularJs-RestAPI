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
    /// Public partial Class [MunicipioService]
    /// </summary>
	[RoutePrefix("services/Municipio")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class MunicipioController : BaseController, IBaseController<MunicipioViewModel>
    {
		/// <summary>
        /// Private readonly [MunicipioService]
        /// </summary>
		private readonly IMunicipioBusiness m_MunicipioBusiness;
		/// <summary>
        /// Constructor [Municipio]
        /// </summary>
        public MunicipioController(IMunicipioBusiness municipioBusiness)
        {
            m_MunicipioBusiness = municipioBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Municipio]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Municipio]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_MunicipioBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Municipio]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Municipio]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_MunicipioBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Municipio]
        /// </summary>
        /// <param name="className">Municipio</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(MunicipioViewModel municipioViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_MunicipioBusiness.Add(municipioViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Municipio]
        /// </summary>
        /// <param name="className">Municipio</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(MunicipioViewModel municipioViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_MunicipioBusiness.Update(municipioViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(MunicipioViewModel municipioViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_MunicipioBusiness.Delete(municipioViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
