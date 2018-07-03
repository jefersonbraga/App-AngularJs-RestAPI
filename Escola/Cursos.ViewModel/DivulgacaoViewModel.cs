///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/19/2017 11:32:18 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
namespace  Cursos.ViewModel
{
	
      public partial class DivulgacaoViewModel
      {
			public int Id { get; set; }
			public string Titulo { get; set; }
			public string Mensagem { get; set; }
			public DateTime Dtcriacao { get; set; }
			public DateTime Dtalteracao { get; set; }
      }
}
