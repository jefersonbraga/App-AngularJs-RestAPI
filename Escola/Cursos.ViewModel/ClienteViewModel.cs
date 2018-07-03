///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/19/2017 11:32:18 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
namespace  Cursos.ViewModel
{
	
      public partial class ClienteViewModel
      {
			public int Id { get; set; }
			public string Userid { get; set; }
			public string Nome { get; set; }
			public string Email { get; set; }
			public string Rg { get; set; }
			public string Orgaoemissor { get; set; }
			public string Ufemissor { get; set; }
			public DateTime Dtemissao { get; set; }
			public string Cpf { get; set; }
			public string Nacionalidade { get; set; }
			public string Naturalidade { get; set; }
			public DateTime? Dtnascimento { get; set; }
			public string Sexo { get; set; }
			public string Nomepai { get; set; }
			public string Nomemae { get; set; }
			public string Cep { get; set; }
			public string Endereco { get; set; }
			public string Bairro { get; set; }
			public int Numero { get; set; }
			public string Complemento { get; set; }
			public string Cidade { get; set; }
			public string Estado { get; set; }
			public string Telresidencial { get; set; }
			public string Telcomercial { get; set; }
			public string Telcelular { get; set; }
			public string Senha { get; set; }
			public string Cadadministracao { get; set; }
			public string Enviosenha { get; set; }
			public int Orgaotrabalhoid { get; set; }
			public int Escolaridadeid { get; set; }
			public string Instituicao { get; set; }
			public DateTime? Dtconclusao { get; set; }
			public DateTime? Dtcadastro { get; set; }
			public DateTime? Dtalteracao { get; set; }
			public DateTime? Dtultimoacesso { get; set; }
			public long? Idantigo { get; set; }
			public int Idorgaoantigo { get; set; }
			public int Idescolaridadeantigo { get; set; }
			public int Qtdacesso { get; set; }
			public int Receberfeeds { get; set; }
			public DateTime? Dtexclusao { get; set; }
      }
}
