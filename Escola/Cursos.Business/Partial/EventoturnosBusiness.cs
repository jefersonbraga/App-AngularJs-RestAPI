using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class EventoturnosBusiness : IEventoturnosBusiness
    {
        public int Add(EventoturnosViewModel entity)
        {
            m_EventoturnosService.Add(new Data.EV_EVENTOTURNOS
            {
                IDEVENTO = entity.Idevento,
                IDTURNO = entity.Idturno,
                DTCADASTRO = DateTime.Now,
                DTATUALIZACAO = DateTime.Now,
            });
            return m_EventoturnosService.Commit();
        }

        public int Delete(EventoturnosViewModel entity)
        {
            var item = m_EventoturnosService.GetById(entity.Idevento);
            if (item != null) 
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_EventoturnosService.Update(item);
            }
            return m_EventoturnosService.Commit();
         
        }

        public IEnumerable<EventoturnosViewModel> GetAll()
        {
            return m_EventoturnosService.GetAll().Select(item => new EventoturnosViewModel
            {
                Idevento = item.IDEVENTO,
                Idturno = item.IDTURNO,
                Descricao = item.IDTURNO == 1 ? "Manha" : item.IDTURNO == 2 ? "Tarde" : "Noite",
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO
            });
        }

        public EventoturnosViewModel GetById(int id)
        {
            var item = m_EventoturnosService.GetById(id);
            if (item == null) return new EventoturnosViewModel();
            return new EventoturnosViewModel
            {
                Idevento = item.IDEVENTO,
                Idturno = item.IDTURNO,
                Descricao = item.IDTURNO == 1 ? "Manha" : item.IDTURNO == 2 ? "Tarde" : "Noite",
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO
            };
        }

        public int Update(EventoturnosViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}