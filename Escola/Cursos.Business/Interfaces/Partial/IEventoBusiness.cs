using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.ViewModel;

namespace Cursos.Business.Interfaces
{
    public partial interface IEventoBusiness
    {
        IEnumerable<EventoViewModel> GetAllCombo();

        EventoPaginacao GetEventoPaginacao(string order, int offset, int limit);

        EventoPaginacao GetEventoPaginacao(string search, string order, int offset, int limit);
    }
}