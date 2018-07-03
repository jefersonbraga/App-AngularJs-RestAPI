///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/19/2017 11:32:18 AM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
namespace  Cursos.ViewModel
{
	
      public partial class RefreshtokenViewModel
      {
			public int Id { get; set; }
			public string Userid { get; set; }
			public string Hash { get; set; }
			public string Protectedticket { get; set; }
			public DateTime Dtemissao { get; set; }
			public DateTime Dtemissaoutc { get; set; }
			public DateTime Dtexpiracao { get; set; }
			public DateTime Dtexpiracaoutc { get; set; }
      }
}
