using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class TipoeventoBusiness : ITipoeventoBusiness
    {
        public int Add(TipoeventoViewModel entity)
        {
            m_TipoeventoService.Add(new Data.EV_TIPOEVENTO
            {
                DESCRICAO = entity.Descricao,
                DTCADASTRO = DateTime.Now,
                DTALTERACAO = DateTime.Now
            });
            return m_TipoeventoService.Commit();
        }

        public int Delete(TipoeventoViewModel entity)
        {
            var item = m_TipoeventoService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_TipoeventoService.Update(item);
            }

            return m_TipoeventoService.Commit();
        }

        public IEnumerable<TipoeventoViewModel> GetAll()
        {
            return m_TipoeventoService.GetAll().Select(item => new TipoeventoViewModel
            {
                Descricao = item.DESCRICAO,
                Dtalteracao = item.DTALTERACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Id = item.ID
            });
        }

        public TipoeventoViewModel GetById(int id)
        {
            var item = m_TipoeventoService.GetById(id);
            if (item == null) return new TipoeventoViewModel();

            return new TipoeventoViewModel
            {
                Descricao = item.DESCRICAO,
                Dtalteracao = item.DTALTERACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Id = item.ID
            };
        }

        public int Update(TipoeventoViewModel entity)
        {
            var item = m_TipoeventoService.GetById(entity.Id);
            if (item == null)
            {
                item.DESCRICAO = entity.Descricao;
                item.DTALTERACAO = DateTime.Now;

                m_TipoeventoService.Update(item);
            }

            return m_TipoeventoService.Commit();
        }
    }
}