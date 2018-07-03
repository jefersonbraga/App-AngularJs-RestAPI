///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/19/2017 11:32:18 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
namespace  Cursos.ViewModel
{
	
      public partial class ListaatividadesViewModel
      {
			public int Id { get; set; }
			public string Usuarioid { get; set; }
			public string Descricao { get; set; }
			public bool Status { get; set; }
			public DateTime Dtcriacao { get; set; }
			public DateTime Dtatualizacao { get; set; }
			public DateTime? Dtexclusao { get; set; }
      }
}
