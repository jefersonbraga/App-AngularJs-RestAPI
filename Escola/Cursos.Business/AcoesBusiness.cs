///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/11/2017 11:29:08 PM
///// Gerado automaticamente para alteracoes alterar o template
///// Para outros metodos implementar classe partial
///// </sumary>
using System;
using System.Collections.Generic;
using Cursos.Business.Interfaces;
using Cursos.Repository.Services.Interfaces;
using Cursos.ViewModel;
namespace  Cursos.Business
{
      public partial class AcoesBusiness 
      {
			private readonly IAcoesService m_AcoesService;
			/// <summary>
			/// Construtor Object Class AD_ACOES
			/// </summary>
			/// <param name="context">context database</param>
			public AcoesBusiness(IAcoesService pAcoesService)
			{
				m_AcoesService = pAcoesService;
			}
      }
}
