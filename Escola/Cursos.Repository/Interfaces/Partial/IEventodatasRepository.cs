using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;

namespace Cursos.Repository.Interfaces
{
    public partial interface IEventodatasRepository
    {
        IEnumerable<EV_EVENTODATAS> GetEventoDataByEvento(int idevento);
    }
}