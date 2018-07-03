using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;
using Cursos.Repository.Services.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Repository.Services
{
    public partial class ClienteService : IClienteService
    {
        public IEnumerable<EV_CLIENTE> GetClientePaginacao(string order, int offset, int limit)
        {
            return UnitOfWork.ClienteRepository.GetClientePaginacao(order, offset, limit);
        }

        public IEnumerable<EV_CLIENTE> GetClientePaginacao(FilterClientes filter, string order, int offset, int limit)
        {
            return UnitOfWork.ClienteRepository.GetClientePaginacao(filter, order, offset, limit);
        }

        public int GetTotalRegistros()
        {
            return UnitOfWork.ClienteRepository.GetTotalRegistros();
        }

        public int GetTotalRegistros(FilterClientes filter)
        {
            return UnitOfWork.ClienteRepository.GetTotalRegistros(filter);
        }

        public IEnumerable<dynamic> GetClientes(int avaliacaoid)
        {
            return UnitOfWork.ClienteRepository.GetClientes(avaliacaoid);
        }
    }
}