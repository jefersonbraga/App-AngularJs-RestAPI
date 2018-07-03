using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.ViewModel;

namespace Cursos.Business.Interfaces
{
    public partial interface IClienteBusiness
    {
        IEnumerable<dynamic> GetClientes(int eventoid);

        ClienteViewModel GetByCpf(string cpf);

        ClienteViewModel1 GetByRefreshToken(string refresh_token);

        IEnumerable<ClienteViewModel> GetTopClientes();

        PaginacaoClientes GetClientePaginacao(string order, int offset, int limit);

        PaginacaoClientes GetClientePaginacao(FilterClientes filter);

        PaginacaoClientes GetClientePaginacao(FilterClientes filter, string order, int offset, int limit);
    }
}