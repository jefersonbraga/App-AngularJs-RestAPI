using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.ViewModel
{
    public partial class ClienteViewModel
    {
        public string OrgaoTrabalho { get; set; }

        public IEnumerable<InscricaoViewModel> Inscricoes { get; set; }
    }
}
