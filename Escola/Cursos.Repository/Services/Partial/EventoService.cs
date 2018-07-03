using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;
using Cursos.Repository.Services.Interfaces;

namespace Cursos.Repository.Services
{
    public partial class EventoService : IEventoService
    {
        public IEnumerable<EV_EVENTO> GetEventoPaginacao(string order, int offset, int limit)
        {
            return UnitOfWork.EventoRepository.GetEventoPaginacao(order, offset, limit);
        }

        public IEnumerable<EV_EVENTO> GetEventoPaginacao(string search, string order, int offset, int limit)
        {
            return UnitOfWork.EventoRepository.GetEventoPaginacao(search, order, offset, limit);
        }

        public IEnumerable<EV_EVENTO> GetAllEventoInscritos()
        {
            return UnitOfWork.EventoRepository.GetAllEventoInscritos();
        }

        public int GetTotalRegistros()
        {
            return UnitOfWork.EventoRepository.GetTotalRegistros();
        }

        public int GetTotalRegistros(string search)
        {
            return UnitOfWork.EventoRepository.GetTotalRegistros(search);
        }
    }
}