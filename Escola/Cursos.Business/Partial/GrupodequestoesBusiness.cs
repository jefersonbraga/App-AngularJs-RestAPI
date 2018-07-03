using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class GrupodequestoesBusiness : IGrupodequestoesBusiness
    {
        public int Add(GrupodequestoesViewModel entity)
        {
            m_GrupodequestoesService.Add(new Data.EV_GRUPODEQUESTOES
            {
                DESCRICAO = entity.Descricao,
                DTATUALIZACAO = DateTime.Now,
                DTCADASTRO = DateTime.Now,
                DTEXCLUSAO = DateTime.Now,
                
            });

            return m_GrupodequestoesService.Commit();
        }

        public int Delete(GrupodequestoesViewModel entity)
        {
            var item = m_GrupodequestoesService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_GrupodequestoesService.Update(item);
            }
            return m_GrupodequestoesService.Commit();
        }

        public IEnumerable<GrupodequestoesViewModel> GetAll()
        {
            return m_GrupodequestoesService.GetAll().Select(item => new GrupodequestoesViewModel
            {
                Descricao = item.DESCRICAO,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Id = item.ID,
            });
        }

        public GrupodequestoesViewModel GetById(int id)
        {
            var item = m_GrupodequestoesService.GetById(id);
            if (item != null)
            {
                return new GrupodequestoesViewModel
                {
                    Descricao = item.DESCRICAO,
                    Dtatualizacao = item.DTATUALIZACAO,
                    Dtcadastro = item.DTCADASTRO,
                    Dtexclusao = item.DTEXCLUSAO,
                    Id = item.ID,
                };
            }
            return new GrupodequestoesViewModel();
        }

        public int Update(GrupodequestoesViewModel entity)
        {
            var item = m_GrupodequestoesService.GetById(entity.Id);
            if (item != null)
            {
                item.DESCRICAO = entity.Descricao;
                item.DTATUALIZACAO = DateTime.Now;
                item.DTCADASTRO = item.DTCADASTRO;

                m_GrupodequestoesService.Update(item);
            }

            return m_GrupodequestoesService.Commit();
        }
    }
}