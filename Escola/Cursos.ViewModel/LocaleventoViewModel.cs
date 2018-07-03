///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/19/2017 11:32:18 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
namespace  Cursos.ViewModel
{
	
      public partial class LocaleventoViewModel
      {
			public int Id { get; set; }
			public string Descricao { get; set; }
			public DateTime Dtcadastro { get; set; }
			public DateTime Dtatualizacao { get; set; }
			public DateTime? Dtexclusao { get; set; }
      }
}
