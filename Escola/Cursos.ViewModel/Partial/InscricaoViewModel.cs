using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.ViewModel
{
    public partial class InscricaoViewModel
    {
        public string NomeCliente { get; set; }
        public string Evento { get; set; }
        public EventoViewModel1 Evento1 { get; set; }
        public string LocalProva { get; set; }
        public string Dtpagamento { get; set; }
        public AlunoViewModel Aluno { get; set; }
    }
}