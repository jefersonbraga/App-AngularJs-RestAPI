using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;

namespace Cursos.Repository
{
    public partial class EventodatasRepository
    {
        public IEnumerable<EV_EVENTODATAS> GetEventoDataByEvento(int idevento)
        {
            return Dbset.Where(x => x.IDEVENTO == idevento).OrderBy(X => X.DTINICIO);
        }
    }
}