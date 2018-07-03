using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class ProvaquestoesBusiness : IProvaquestoesBusiness
    {
        public int Add(ProvaquestoesViewModel entity)
        {
            m_ProvaquestoesService.Add(new Data.EV_PROVAQUESTOES
            {
                DESCRICAO = entity.Descricao,
                DTATUALIZACAO = DateTime.Now,
                DTCADASTRO = DateTime.Now,
                GRUPOQUESTOESID = entity.Grupoquestoesid,
            });
            return m_ProvaquestoesService.Commit();
        }

        public int Delete(ProvaquestoesViewModel entity)
        {
            var item = m_ProvaquestoesService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_ProvaquestoesService.Update(item);
            }

            return m_ProvaquestoesService.Commit();
        }

        public IEnumerable<ProvaquestoesViewModel> GetAll()
        {
            return m_ProvaquestoesService.GetAll().Select(item => new ProvaquestoesViewModel
            {
                Descricao = item.DESCRICAO,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Grupoquestoesid = item.GRUPOQUESTOESID,
                Id = item.ID,
                
            });
        }

        public ProvaquestoesViewModel GetById(int id)
        {
            var item = m_ProvaquestoesService.GetById(id);
            if (item != null)
            {
                return new ProvaquestoesViewModel
                {
                    Descricao = item.DESCRICAO,
                    Grupoquestoesid = item.GRUPOQUESTOESID,
                    Dtatualizacao = item.DTATUALIZACAO,
                    Dtcadastro = item.DTCADASTRO,
                    Dtexclusao = item.DTEXCLUSAO,
                    Id = item.ID,
                };
            }
            return new ProvaquestoesViewModel();
        }

        public int Update(ProvaquestoesViewModel entity)
        {
            var item = m_ProvaquestoesService.GetById(entity.Id);
            if (item != null)
            {
                item.DESCRICAO = entity.Descricao;
                item.DTATUALIZACAO = DateTime.Now;
                item.DTCADASTRO = entity.Dtatualizacao;
                m_ProvaquestoesService.Update(item);
            }

            return m_ProvaquestoesService.Commit();
        }
    }
}