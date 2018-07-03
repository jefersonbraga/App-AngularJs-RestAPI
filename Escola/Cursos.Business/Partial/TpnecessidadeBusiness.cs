using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;
namespace Cursos.Business
{
    public partial class TpnecessidadeBusiness : ITpnecessidadeBusiness
    {
        public int Add(TpnecessidadeViewModel entity)
        {
            m_TpnecessidadeService.Add(new Data.EV_TPNECESSIDADE{
                //ID = entity.Id,
                TIPONECESSIDADE = entity.Tiponecessidade

            });

            return m_TpnecessidadeService.Commit();
        }

        public int Delete(TpnecessidadeViewModel entity)
        {
            var item = m_TpnecessidadeService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_TpnecessidadeService.Update(item);
            }
            return m_TpnecessidadeService.Commit();
        }

        public IEnumerable<TpnecessidadeViewModel> GetAll()
        {
            return m_TpnecessidadeService.GetAll().Select(item => new TpnecessidadeViewModel {
                Id = item.ID,
                Tiponecessidade = item.TIPONECESSIDADE,
            });
        }

        public TpnecessidadeViewModel GetById(int id)
        {
            var item = m_TpnecessidadeService.GetById(id);
            if (item != null)
            {
                return new TpnecessidadeViewModel
                {
                    Id = item.ID,
                    Tiponecessidade = item.TIPONECESSIDADE,
                };

            }
            return new TpnecessidadeViewModel();
        }

        public int Update(TpnecessidadeViewModel entity)
        {
            var item = m_TpnecessidadeService.GetById(entity.Id);
            if (item != null)
            {
                item.TIPONECESSIDADE = entity.Tiponecessidade;
                m_TpnecessidadeService.Update(item);
            }
            
            return m_TpnecessidadeService.Commit();
        }
    }
}
