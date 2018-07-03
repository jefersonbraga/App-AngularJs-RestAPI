///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/19/2017 11:32:18 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
namespace  Cursos.ViewModel
{
	
      public partial class InscricaoViewModel
      {
			public int Id { get; set; }
			public int Clienteid { get; set; }
			public int Eventoid { get; set; }
			public int Neespecialid { get; set; }
			public DateTime Dtinscricao { get; set; }
			public decimal Valor { get; set; }
			public string Formapagamento { get; set; }
			public string Pago { get; set; }
			public DateTime? Dtboletoemitido { get; set; }
			public string Boletoemitido { get; set; }
			public DateTime? Datapagamento { get; set; }
			public decimal? Valorrecebido { get; set; }
			public string Turno { get; set; }
			public string Cargo { get; set; }
			public string Sala { get; set; }
			public string Fase01 { get; set; }
			public string Fase02 { get; set; }
			public string Fase03 { get; set; }
			public string Fase04 { get; set; }
			public int Localprovaid { get; set; }
			public int Salaid { get; set; }
			public string Baixa { get; set; }
			public DateTime? Criado { get; set; }
			public DateTime Dtcadastro { get; set; }
			public DateTime Dtalteracao { get; set; }
			public DateTime? Dtexclusao { get; set; }
      }
}
