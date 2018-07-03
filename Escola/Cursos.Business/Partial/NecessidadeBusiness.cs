using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;
namespace Cursos.Business
{
    public partial class NecessidadeBusiness : INecessidadeBusiness
    {

        public int Add(NecessidadeViewModel entity)
        {
            m_NecessidadeService.Add(new Data.EV_NECESSIDADE {
                //ID = entity.Id,
                NECESSIDADE = entity.Necessidade,
                TIPONECESSIDADEID = entity.Tiponecessidadeid,
            });
            return m_NecessidadeService.Commit();
        }

        public int Delete(NecessidadeViewModel entity)
        {
            var item = m_NecessidadeService.GetById(entity.Id);
            if (item != null)
            {
                m_NecessidadeService.Delete(item);
            }
            return m_NecessidadeService.Commit();
        }

        public IEnumerable<NecessidadeViewModel> GetAll()
        {
            return m_NecessidadeService.GetAll().Select(item => new NecessidadeViewModel {
                Id = item.ID,
                Necessidade = item.NECESSIDADE,
                Tiponecessidadeid = item.TIPONECESSIDADEID ?? 0,
            });
        }

        public NecessidadeViewModel GetById(int id)
        {
            var item = m_NecessidadeService.GetById(id);
            if (item != null)
            {
                return new NecessidadeViewModel
                {
                    Id = item.ID,
                    Necessidade = item.NECESSIDADE,
                    Tiponecessidadeid = item.TIPONECESSIDADEID ?? 0,
                };

            }
            return new NecessidadeViewModel();
        }

        public int Update(NecessidadeViewModel entity)
        {
            var item = m_NecessidadeService.GetById(entity.Id);
            if (item != null)
            {
                item.NECESSIDADE = entity.Necessidade;
                item.TIPONECESSIDADEID = entity.Tiponecessidadeid;
                m_NecessidadeService.Update(item);
            }
            
            return m_NecessidadeService.Commit();
        }
    }
}
