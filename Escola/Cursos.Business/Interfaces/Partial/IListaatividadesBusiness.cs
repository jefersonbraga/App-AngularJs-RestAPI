using System.Collections.Generic;
using Cursos.ViewModel;

namespace Cursos.Business.Interfaces
{
    public partial interface IListaatividadesBusiness
    {
        IEnumerable<ListaatividadesViewModel> GetByUser(string userid);
    }
}