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
      public partial class ModulosBusiness 
      {
			private readonly IModulosService m_ModulosService;
			/// <summary>
			/// Construtor Object Class AD_MODULOS
			/// </summary>
			/// <param name="context">context database</param>
			public ModulosBusiness(IModulosService pModulosService)
			{
				m_ModulosService = pModulosService;
			}
      }
}
