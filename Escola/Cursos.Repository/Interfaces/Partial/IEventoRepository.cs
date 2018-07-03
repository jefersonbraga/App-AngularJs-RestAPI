using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;

namespace Cursos.Repository.Interfaces
{
    public partial interface IEventoRepository
    {
        IEnumerable<EV_EVENTO> GetAllEventoInscritos();

        IEnumerable<EV_EVENTO> GetEventoPaginacao(string order, int offset, int limit);

        IEnumerable<EV_EVENTO> GetEventoPaginacao(string search, string order, int offset, int limit);

        int GetTotalRegistros();

        int GetTotalRegistros(string search);
    }
}