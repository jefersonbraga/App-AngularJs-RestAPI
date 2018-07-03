///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/19/2017 11:32:18 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
namespace  Cursos.ViewModel
{
	
      public partial class DivulgacaoenviosViewModel
      {
			public int Id { get; set; }
			public int Iddivulgacao { get; set; }
			public int Idevento { get; set; }
			public int Idorgaotrabalho { get; set; }
			public string Dsletraalfabeto { get; set; }
			public string Emailteste { get; set; }
			public string Emailremetente { get; set; }
			public string Assunto { get; set; }
			public DateTime Dtcadastro { get; set; }
			public DateTime Dtalteracao { get; set; }
			public DateTime? Dtexclusao { get; set; }
      }
}
