///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/19/2017 11:32:18 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
namespace  Cursos.ViewModel
{
	
      public partial class EventoViewModel
      {
			public int Id { get; set; }
			public string Nome { get; set; }
			public int Localid { get; set; }
			public string Tpevento { get; set; }
			public string Situacao { get; set; }
			public string Disponivel { get; set; }
			public string Exibirlocal { get; set; }
			public string Inscricao { get; set; }
			public int Temaid { get; set; }
			public decimal Valorevento { get; set; }
			public int Qtdvagas { get; set; }
			public decimal Frequencia { get; set; }
			public DateTime? Dtinicio { get; set; }
			public DateTime? Dttermino { get; set; }
			public TimeSpan? Horainicio { get; set; }
			public TimeSpan? Horatermino { get; set; }
			public string Endereco { get; set; }
			public DateTime? Vecimentoboleto { get; set; }
			public string Descricao { get; set; }
			public string Mensagemboleto { get; set; }
			public string Mensagemcomprovante { get; set; }
			public int Idantigo { get; set; }
			public DateTime Dtcadastro { get; set; }
			public DateTime Dtatualizacao { get; set; }
			public DateTime? Dtexclusao { get; set; }
      }
}
