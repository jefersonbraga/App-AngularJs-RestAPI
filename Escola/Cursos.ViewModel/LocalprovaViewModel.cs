///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/19/2017 11:32:18 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
namespace  Cursos.ViewModel
{
	
      public partial class LocalprovaViewModel
      {
			public int Id { get; set; }
			public string Local { get; set; }
			public string Cep { get; set; }
			public string Logradouro { get; set; }
			public string Endereco { get; set; }
			public string Bairro { get; set; }
			public string Complemento { get; set; }
			public int Numero { get; set; }
			public string Cidade { get; set; }
			public string Estado { get; set; }
      }
}
