using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.Data;
using Cursos.ViewModel;
namespace Cursos.Business
{
    public partial class ControlenecessidadeBusiness : IControlenecessidadeBusiness
    {
        public int Add(ControlenecessidadeViewModel entity)
        {
            m_ControlenecessidadeService.Add(new EV_CONTROLENECESSIDADE {
                CLIENTEID = entity.Clienteid,
                NECESSIDADEID = entity.Necessidadeid,
                INCRICAOID = entity.Incricaoid,
            });

            return m_ControlenecessidadeService.Commit();
        }

        public int Delete(ControlenecessidadeViewModel entity)
        {
            var item = m_ControlenecessidadeService.GetById(entity.Id);
            if (item != null)
            {
                m_ControlenecessidadeService.Delete(item);
            }

            return m_ControlenecessidadeService.Commit();
        }

        public IEnumerable<ControlenecessidadeViewModel> GetAll()
        {
            return m_ControlenecessidadeService.GetAll().Select(item => new ControlenecessidadeViewModel {
                Id = item.ID,
                Clienteid = item.CLIENTEID ?? 0,
                Incricaoid = item.INCRICAOID ?? 0,
                Necessidadeid = item.NECESSIDADEID ?? 0,  
            });
        }

        public ControlenecessidadeViewModel GetById(int id)
        {
            var item = m_ControlenecessidadeService.GetById(id);
            if (item != null)
            {
                return new ControlenecessidadeViewModel
                {
                    Id = item.ID,
                    Clienteid = item.CLIENTEID ?? 0,
                    Incricaoid = item.INCRICAOID ?? 0,
                    Necessidadeid = item.NECESSIDADEID ?? 0,
                };
            }

            return new ControlenecessidadeViewModel();
        }

        public int Update(ControlenecessidadeViewModel entity)
        {
            var item = m_ControlenecessidadeService.GetById(entity.Id);
            if (item != null)
            {
                item.CLIENTEID = entity.Clienteid;
                item.INCRICAOID = entity.Incricaoid;
                item.NECESSIDADEID = entity.Necessidadeid;
            }

            return m_ControlenecessidadeService.Commit();
        }
    }
}
