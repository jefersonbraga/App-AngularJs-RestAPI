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
      public partial class ProvaquestoesBusiness 
      {
			private readonly IProvaquestoesService m_ProvaquestoesService;
			/// <summary>
			/// Construtor Object Class EV_PROVAQUESTOES
			/// </summary>
			/// <param name="context">context database</param>
			public ProvaquestoesBusiness(IProvaquestoesService pProvaquestoesService)
			{
				m_ProvaquestoesService = pProvaquestoesService;
			}
      }
}
