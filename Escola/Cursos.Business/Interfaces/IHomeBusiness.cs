using System.Collections.Generic;
using Cursos.ViewModel;

namespace Cursos.Business.Interfaces
{
    public interface IHomeBusiness
    {
        IEnumerable<AcoesViewModel> GetMenu();
    }
}