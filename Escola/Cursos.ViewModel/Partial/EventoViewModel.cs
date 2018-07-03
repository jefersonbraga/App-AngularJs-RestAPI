using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.ViewModel
{
    public partial class EventoViewModel
    {
        public SituacaoeventoViewModel SituacaoEvento { get; set; }
        public TipoeventoViewModel TipoEvento { get; set; }
        public IEnumerable<EventoturnosViewModel> Turnos { get; set; }
        public string DataInicio { get; set; }
        public string DataTermino { get; set; }
        public IEnumerable<EventodatasViewModel> Eventodatas { get; set; }
    }
}