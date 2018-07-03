using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class LocaleventoBusiness : ILocaleventoBusiness
    {
        public int Add(LocaleventoViewModel entity)
        {
            m_LocaleventoService.Add(new Data.EV_LOCALEVENTO {
                DESCRICAO = entity.Descricao,
                DTCADASTRO = DateTime.Now,
                DTATUALIZACAO = DateTime.Now
            });

            return m_LocaleventoService.Commit();
        }

        public int Delete(LocaleventoViewModel entity)
        {
            var item = m_LocaleventoService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_LocaleventoService.Update(item);
            }
            return m_LocaleventoService.Commit();
        }

        public IEnumerable<LocaleventoViewModel> GetAll()
        {
            return m_LocaleventoService.GetAll().Select(item => new LocaleventoViewModel {
                Descricao = item.DESCRICAO,
                Dtcadastro = item.DTCADASTRO,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtexclusao = item.DTEXCLUSAO,
                Id = item.ID
            });
        }

        public LocaleventoViewModel GetById(int id)
        {
            var item = m_LocaleventoService.GetById(id);
            if (item != null)
            {
                return new LocaleventoViewModel
                {
                    Descricao = item.DESCRICAO,
                    Dtcadastro = item.DTCADASTRO,
                    Dtatualizacao = item.DTATUALIZACAO,
                    Dtexclusao = item.DTEXCLUSAO.Value,
                    Id = item.ID
                };
            }
            return null;
        }

        public int Update(LocaleventoViewModel entity)
        {
            var entityUpdate = m_LocaleventoService.GetById(entity.Id);
            if (entityUpdate != null) {
                entityUpdate.DESCRICAO = entity.Descricao;
                entityUpdate.DTATUALIZACAO = DateTime.Now;
            }
            return m_LocaleventoService.Commit();
        }
    }
}
