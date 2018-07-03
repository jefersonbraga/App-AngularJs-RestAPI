using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;
namespace Cursos.Business
{
    public partial class SalalocalprovaBusiness : ISalalocalprovaBusiness
    {
        public int Add(SalalocalprovaViewModel entity)
        {
            m_SalalocalprovaService.Add(new Data.EV_SALALOCALPROVA {
                //ID = entity.Id,
                LOCALPROVAID = entity.Localprovaid,
                SALA = entity.Sala,
            });

            return m_SalalocalprovaService.Commit();
        }

        public int Delete(SalalocalprovaViewModel entity)
        {
            var item = m_SalalocalprovaService.GetById(entity.Id);
            if (item != null)
            {
                m_SalalocalprovaService.Delete(item);
            }
            return m_SalalocalprovaService.Commit();
        }


        public IEnumerable<SalalocalprovaViewModel> GetAll()
        {
            return m_SalalocalprovaService.GetAll().Select(item => new SalalocalprovaViewModel {
                Id = item.ID,
                Localprovaid = item.LOCALPROVAID ?? 0,
                Sala = item.SALA,
            });
        }

        public SalalocalprovaViewModel GetById(int id)
        {
            var item = m_SalalocalprovaService.GetById(id);
            if (item != null)
            {
                return new SalalocalprovaViewModel
                {
                    Id = item.ID,
                    Localprovaid = item.LOCALPROVAID ?? 0,
                    Sala = item.SALA,
                };

            }
            return new SalalocalprovaViewModel();
        }

        public int Update(SalalocalprovaViewModel entity)
        {
            var item = m_SalalocalprovaService.GetById(entity.Id);
            if (item != null )
            {
                item.LOCALPROVAID = entity.Localprovaid;
                item.SALA = entity.Sala;
                m_SalalocalprovaService.Update(item);
            }
            
            return m_SalalocalprovaService.Commit();
        }
    }
}
