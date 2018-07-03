using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.Data;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class ListaatividadesBusiness : IListaatividadesBusiness
    {
        public int Add(ListaatividadesViewModel entity)
        {
            m_ListaatividadesService.Add(new ES_LISTAATIVIDADES {
                ID = entity.Id,
                DESCRICAO = entity.Descricao,
                DT_CRIACAO = DateTime.Now,
                DT_ATUALIZACAO = DateTime.Now,
                STATUS = entity.Status,
                USUARIOID = entity.Usuarioid
            });
            return m_ListaatividadesService.Commit();
        }

        public int Delete(ListaatividadesViewModel entity)
        {
            var item = m_ListaatividadesService.GetById(entity.Id);
            if (item != null)
            {
                item.DT_EXCLUSAO = DateTime.Now;
                m_ListaatividadesService.Update(item);
            }
            
            return m_ListaatividadesService.Commit();
        }

        public IEnumerable<ListaatividadesViewModel> GetAll()
        {
            return m_ListaatividadesService.GetAll().Select(item => new ListaatividadesViewModel {
                Id = item.ID,
                Descricao = item.DESCRICAO,
                Dtcriacao = item.DT_CRIACAO,
                Status = item.STATUS,
                Dtexclusao = item.DT_EXCLUSAO.Value,
                Dtatualizacao = item.DT_ATUALIZACAO
            });
        }

        public ListaatividadesViewModel GetById(int id)
        {
            var item = m_ListaatividadesService.GetById(id);

            if (item != null)
            {
                return new ListaatividadesViewModel
                {
                    Id = item.ID,
                    Descricao = item.DESCRICAO,
                    Dtcriacao = item.DT_CRIACAO,
                    Status = item.STATUS,
                    Dtexclusao = item.DT_EXCLUSAO.Value,
                    Dtatualizacao = item.DT_ATUALIZACAO
                };
            }
            return new ListaatividadesViewModel();
        }

        public IEnumerable<ListaatividadesViewModel> GetByUser(string userid)
        {
            return m_ListaatividadesService.FindBy(x=>x.USUARIOID == userid).Select(item=> new ListaatividadesViewModel
            {
                Id = item.ID,
                Descricao = item.DESCRICAO,
                Dtcriacao = item.DT_CRIACAO,
                Status = item.STATUS,
                Dtexclusao = item.DT_EXCLUSAO.Value,
                Dtatualizacao = item.DT_ATUALIZACAO
            });
         
        }

        public int Update(ListaatividadesViewModel entity)
        {
            var item = m_ListaatividadesService.GetById(entity.Id);
            if (item != null)
            {
                item.DESCRICAO = entity.Descricao;
                item.DT_ATUALIZACAO = DateTime.Now;
                item.STATUS = entity.Status;
                m_ListaatividadesService.Update(item);
            }

            return m_ListaatividadesService.Commit();
        }
    }
}
