using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class RecursoprovaBusiness : IRecursoprovaBusiness
    {
        public int Add(RecursoprovaViewModel entity)
        {
            m_RecursoprovaService.Add(new Data.EV_RECURSOPROVA
            {
                EVENTOID = entity.Eventoid,
                DTATUALIZACAO = DateTime.Now,
                DTCADASTRO = DateTime.Now,
                DTEXCLUSAO = DateTime.Now,
                DTINICIO = entity.Dtinicio,
                DTTERMINO = entity.Dttermino,
                HRINICIO = entity.Hrinicio,
                TITULO = entity.Titulo
            });
            return m_RecursoprovaService.Commit();
        }
        public int Delete(RecursoprovaViewModel entity)
        {
            var item = m_RecursoprovaService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_RecursoprovaService.Update(item);
            }
            return m_RecursoprovaService.Commit();
        }
        public IEnumerable<RecursoprovaViewModel> GetAll()
        {
            return m_RecursoprovaService.GetAll().Select(item => new RecursoprovaViewModel
            {
                Eventoid = item.EVENTOID,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Dtinicio = item.DTINICIO,
                Dttermino = item.DTTERMINO,
                Hrinicio = item.HRINICIO,
                Titulo = item.TITULO,
                Id = item.ID
            });
        }
        public RecursoprovaViewModel GetById(int id)
        {
            var item = m_RecursoprovaService.GetById(id);
            if (item != null)
            {
                return new RecursoprovaViewModel
                {
                    Eventoid = item.EVENTOID,
                    Dtatualizacao = item.DTATUALIZACAO,
                    Dtcadastro = item.DTCADASTRO,
                    Dtexclusao = item.DTEXCLUSAO,
                    Dtinicio = item.DTINICIO,
                    Dttermino = item.DTTERMINO,
                    Hrinicio = item.HRINICIO,
                    Titulo = item.TITULO,
                    Id = item.ID
                };
            }
            return new RecursoprovaViewModel();
        }
        public int Update(RecursoprovaViewModel entity)
        {
            var item = m_RecursoprovaService.GetById(entity.Id);
            if (item != null)
            {
                item.EVENTOID = entity.Eventoid;
                item.TITULO = entity.Titulo;
                item.DTATUALIZACAO = DateTime.Now;
                item.DTTERMINO = entity.Dttermino;
                item.DTINICIO = entity.Dtinicio;
                item.HRINICIO = entity.Hrinicio;
                m_RecursoprovaService.Update(item);
            }
            return m_RecursoprovaService.Commit();
        }
    }
}