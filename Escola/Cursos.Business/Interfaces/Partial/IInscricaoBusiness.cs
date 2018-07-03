using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.ViewModel;

namespace Cursos.Business.Interfaces
{
    public partial interface IInscricaoBusiness
    {
        IEnumerable<InscricaoViewModel> GetByClientId(int id);

        IEnumerable<InscricaoViewModel> GetTopInscricoes();

        PaginacaoInscricao GetInscricaoPaginacao(string order, int offset, int limit);
        PaginacaoInscricao GetInscricaoPaginacao(string search, string order, int offset, int limit);
    }
}
