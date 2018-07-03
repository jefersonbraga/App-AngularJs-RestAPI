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
    /// Public partial Class [MenuService]
    /// </summary>
	[RoutePrefix("services/Menu")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class MenuController : BaseController, IBaseController<MenuViewModel>
    {
		/// <summary>
        /// Private readonly [MenuService]
        /// </summary>
		private readonly IMenuBusiness m_MenuBusiness;
		/// <summary>
        /// Constructor [Menu]
        /// </summary>
        public MenuController(IMenuBusiness menuBusiness)
        {
            m_MenuBusiness = menuBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Menu]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Menu]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_MenuBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Menu]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Menu]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_MenuBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Menu]
        /// </summary>
        /// <param name="className">Menu</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(MenuViewModel menuViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_MenuBusiness.Add(menuViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Menu]
        /// </summary>
        /// <param name="className">Menu</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(MenuViewModel menuViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_MenuBusiness.Update(menuViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(MenuViewModel menuViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_MenuBusiness.Delete(menuViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
