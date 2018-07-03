using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.ViewModel;

namespace Cursos.Business.Interfaces
{
    public partial interface IUfBusiness
    {
        UfViewModel GetByUf(string uf);
    }
}
