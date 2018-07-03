using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;

namespace Cursos.Repository.Services.Interfaces
{
    public partial interface IInscricaoService
    {
        IEnumerable<EV_INSCRICAO> GetInscricaoByClienteId(int clientId);

        IEnumerable<EV_INSCRICAO> GetInscricaoPaginacao(string order, int offset, int limit);
        IEnumerable<EV_INSCRICAO> GetInscricaoPaginacao(string search, string order, int offset, int limit);

        int GetTotalRegistros();
        int GetTotalRegistros(string search);

    }
}
