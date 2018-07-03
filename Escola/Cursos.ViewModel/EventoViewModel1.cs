using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.ViewModel
{
    public class EventoViewModel1
    {
        public string Nome { get; set; }
        public DateTime? Dtevento { get; set; }
        public TimeSpan? Horainicio { get; set; }
        public TimeSpan? Horatermino { get; set; }
        public string Localevento { get; set; }
    }
}