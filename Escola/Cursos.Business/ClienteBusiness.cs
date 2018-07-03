///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/11/2017 11:29:08 PM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
using System.Collections.Generic;
using Cursos.Business.Interfaces;
using Cursos.Repository.Services.Interfaces;
using Cursos.ViewModel;
namespace  Cursos.Business
{
      public partial class ClienteBusiness 
      {
			private readonly IClienteService m_ClienteService;
			/// <summary>
			/// Construtor Object Class EV_CLIENTE
			/// </summary>
			/// <param name="context">context database</param>
			public ClienteBusiness(IClienteService pClienteService)
			{
				m_ClienteService = pClienteService;
			}
      }
}
