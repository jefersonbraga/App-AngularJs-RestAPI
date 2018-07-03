using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;
using Cursos.Repository.Services.Interfaces;

namespace Cursos.Repository.Services
{
    public partial class InscricaoService : IInscricaoService
    {
        public IEnumerable<EV_INSCRICAO> GetInscricaoByClienteId(int clienteId)
        {
            return UnitOfWork.InscricaoRepository.GetInscricaoByClienteId(clienteId);
        }
        public IEnumerable<EV_INSCRICAO> GetInscricaoPaginacao(string search, string order, int offset, int limit)
        {
            return UnitOfWork.InscricaoRepository.GetInscricaoPaginacao(search, order, offset, limit);
        }

        public IEnumerable<EV_INSCRICAO> GetInscricaoPaginacao(string order, int offset, int limit)
        {
            return UnitOfWork.InscricaoRepository.GetInscricaoPaginacao(order, offset, limit);
        }

        public int GetTotalRegistros()
        {
            return UnitOfWork.InscricaoRepository.GetTotalRegistros();
        }

        public int GetTotalRegistros(string search)
        {
            return UnitOfWork.InscricaoRepository.GetTotalRegistros(search);
        }
    }
}
