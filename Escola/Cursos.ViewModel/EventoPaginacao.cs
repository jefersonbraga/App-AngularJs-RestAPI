using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.ViewModel
{
    public class EventoPaginacao
    {
        public int total { get; set; }
        public IEnumerable<EventoViewModel> rows { get; set; }
    }
}