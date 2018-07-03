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
    /// Public partial Class [ListaatividadesService]
    /// </summary>
	[RoutePrefix("services/Listaatividades")]
	[EnableCors(origins: "*", headers: "*", methods: "*")]
    public partial class ListaatividadesController : BaseController, IBaseController<ListaatividadesViewModel>
    {
		/// <summary>
        /// Private readonly [ListaatividadesService]
        /// </summary>
		private readonly IListaatividadesBusiness m_ListaatividadesBusiness;
		/// <summary>
        /// Constructor [Listaatividades]
        /// </summary>
        public ListaatividadesController(IListaatividadesBusiness listaatividadesBusiness)
        {
            m_ListaatividadesBusiness = listaatividadesBusiness;
        }
		/// <summary>
        /// Method GetAll() [m_Listaatividades]
        /// </summary>
        /// <returns>HttpResponseMessage Content List Object JSON[Listaatividades]</returns>
        [Route("getAll")]
        public HttpResponseMessage GetAll()
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_ListaatividadesBusiness.GetAll());
        }
		/// <summary>
        /// Method GetById [m_Listaatividades]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpResponseMessage Content Object JSON[Listaatividades]</returns>
        [Route("getById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
			return Request.CreateResponse(HttpStatusCode.OK, m_ListaatividadesBusiness.GetById(id));
        }
		/// <summary>
        /// Method Create Object [m_Listaatividades]
        /// </summary>
        /// <param name="className">Listaatividades</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("post")]
        [HttpPost]
        public HttpResponseMessage Add(ListaatividadesViewModel listaatividadesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ListaatividadesBusiness.Add(listaatividadesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
		
		/// <summary>
        /// Method Update Object [m_Listaatividades]
        /// </summary>
        /// <param name="className">Listaatividades</param>
        /// <returns>HttpResponseMessage</returns>
        [Route("put")]
        [HttpPost]
        public HttpResponseMessage Update(ListaatividadesViewModel listaatividadesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ListaatividadesBusiness.Update(listaatividadesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }

		[Route("delete")]
		[HttpPost]
        public HttpResponseMessage Delete(ListaatividadesViewModel listaatividadesViewModel)
        {
			try
            {
                return Request.CreateResponse(HttpStatusCode.OK, m_ListaatividadesBusiness.Delete(listaatividadesViewModel));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Format("Error:{0}!", ex.Message));
            }
        }
    }
}
