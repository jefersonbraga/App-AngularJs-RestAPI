///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/19/2017 11:32:18 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
namespace  Cursos.ViewModel
{
	
      public partial class MenuViewModel
      {
			public int Id { get; set; }
			public string Menu { get; set; }
			public int Acoesid { get; set; }
			public string Link { get; set; }
			public int Ordem { get; set; }
			public bool? Ativo { get; set; }
      }
}
