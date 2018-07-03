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
      public partial class OrgaosBusiness 
      {
			private readonly IOrgaosService m_OrgaosService;
			/// <summary>
			/// Construtor Object Class AD_ORGAOS
			/// </summary>
			/// <param name="context">context database</param>
			public OrgaosBusiness(IOrgaosService pOrgaosService)
			{
				m_OrgaosService = pOrgaosService;
			}
      }
}
