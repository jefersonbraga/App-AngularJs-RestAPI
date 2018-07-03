using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class SituacaoeventoBusiness : ISituacaoeventoBusiness
    {
        public int Add(SituacaoeventoViewModel entity)
        {
            m_SituacaoeventoService.Add(new Data.EV_SITUACAOEVENTO
            {
                DESCRICAO = entity.Descricao,
                DTCADASTRO = entity.Dtcadastro,
                DTATUALIZACAO = entity.Dtatualizacao
            });
            return m_SituacaoeventoService.Commit();
        }

        public int Delete(SituacaoeventoViewModel entity)
        {
            var item = m_SituacaoeventoService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_SituacaoeventoService.Update(item);
            }

            return m_SituacaoeventoService.Commit();
        }

        public IEnumerable<SituacaoeventoViewModel> GetAll()
        {
            return m_SituacaoeventoService.GetAll().Select(item => new SituacaoeventoViewModel
            {
                Descricao = item.DESCRICAO,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Id = item.ID
            });
        }

        public SituacaoeventoViewModel GetById(int id)
        {
            var item = m_SituacaoeventoService.GetById(id);
            if (item == null) return new SituacaoeventoViewModel();

            return new SituacaoeventoViewModel
            {
                Descricao = item.DESCRICAO,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Id = item.ID
            };
        }

        public int Update(SituacaoeventoViewModel entity)
        {
            var item = m_SituacaoeventoService.GetById(entity.Id);
            if (item == null)
            {
                item.DESCRICAO = entity.Descricao;
                item.DTATUALIZACAO = DateTime.Now;

                m_SituacaoeventoService.Update(item);
            }

            return m_SituacaoeventoService.Commit();
        }
    }
}