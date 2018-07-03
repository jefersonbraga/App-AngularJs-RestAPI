using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;
using Cursos.ViewModel;

namespace Cursos.Repository.Services.Interfaces
{
    public partial interface IClienteService
    {
        IEnumerable<dynamic> GetClientes(int eventoid);

        IEnumerable<EV_CLIENTE> GetClientePaginacao(string order, int offset, int limit);

        IEnumerable<EV_CLIENTE> GetClientePaginacao(FilterClientes filter, string order, int offset, int limit);

        int GetTotalRegistros();

        int GetTotalRegistros(FilterClientes filter);
    }
}