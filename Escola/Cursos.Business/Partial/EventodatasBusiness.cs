using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class EventodatasBusiness : IEventodatasBusiness
    {
        public int Add(EventodatasViewModel entity)
        {
            if (entity.Dtinicio == DateTime.MinValue)
                entity.Dtinicio = DateTime.Now;

            if (entity.Dttermino == DateTime.MinValue)
                entity.Dttermino = DateTime.Now;

            m_EventodatasService.Add(new Data.EV_EVENTODATAS
            {
                DTINICIO = entity.Dtinicio,
                DTTERMINO = entity.Dttermino,
                HORAINICIO = entity.Horainicio,
                HORATERMINO = entity.Horatermino,
                IDEVENTO = entity.Idevento,
            });

            return m_EventodatasService.Commit();
        }

        public int Delete(EventodatasViewModel entity)
        {
            var item = m_EventodatasService.GetById(entity.Id);
            if (item != null)
                m_EventodatasService.Delete(item);

            return m_EventodatasService.Commit();
        }

        public IEnumerable<EventodatasViewModel> GetAll()
        {
            return m_EventodatasService.GetAll().Select(item => new EventodatasViewModel()
            {
                Dtinicio = item.DTINICIO,
                Dttermino = item.DTTERMINO,
                Horainicio = item.HORAINICIO,
                Horatermino = item.HORATERMINO,
                Idevento = item.IDEVENTO,
                Id = item.ID
            });
        }

        public EventodatasViewModel GetById(int id)
        {
            var item = m_EventodatasService.GetById(id);
            if (item != null)
            {
                return new EventodatasViewModel()
                {
                    Dtinicio = item.DTINICIO,
                    Dttermino = item.DTTERMINO,
                    Horainicio = item.HORAINICIO,
                    Horatermino = item.HORATERMINO,
                    Idevento = item.IDEVENTO,
                    Id = item.ID
                };
            }
            return new EventodatasViewModel();
        }

        public int Update(EventodatasViewModel entity)
        {
            var item = m_EventodatasService.GetById(entity.Id);
            if (item != null)
            {
                item.DTINICIO = entity.Dtinicio;
                item.DTTERMINO = entity.Dttermino;
                item.HORAINICIO = entity.Horainicio;
                item.HORATERMINO = entity.Horatermino;
                m_EventodatasService.Update(item);
            }
            return m_EventodatasService.Commit();
        }
    }
}