using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;

namespace Cursos.Repository.Services
{
    public partial class EventodatasService
    {
        public IEnumerable<EV_EVENTODATAS> GetEventoDataByEvento(int idevento)
        {
            return UnitOfWork.EventodatasRepository.GetEventoDataByEvento(idevento);
        }
    }
}