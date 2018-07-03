using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.ViewModel;

namespace Cursos.Business.Interfaces
{
    public partial interface IOrgaoemissorBusiness
    {
        OrgaoemissorViewModel GetByOrgao(string orgao);
    }
}
