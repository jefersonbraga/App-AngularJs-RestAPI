using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class AvaliacaoBusiness : IAvaliacaoBusiness
    {
        public int Add(AvaliacaoViewModel entity)
        {
            if (entity.Eventoid <= 0) throw new Exception("Favor informe um evento.");
            m_AvaliacaoService.Add(new Data.EV_AVALIACAO
            {
                DTALTERACAO = DateTime.Now,
                DTCADASTRO = DateTime.Now,
                DESCRICAO = entity.Descricao,
                DISPONIVEL = entity.Disponivel,
                DTINICIO = entity.Dtinicio,
                DTTERMINO = entity.Dttermino,
                EVENTOID = entity.Eventoid,
                HORAINICIO = entity.Horainicio,
                HORATERMINO = entity.Horatermino,
                ID = entity.Id,

                TITULO = entity.Titulo,
            });
            return m_AvaliacaoService.Commit();
        }

        public int Delete(AvaliacaoViewModel entity)
        {
            try
            {
                var item = m_AvaliacaoService.GetById(entity.Id);

                if (item != null)
                {
                    m_AvaliacaoService.Delete(item);
                }
                return m_AvaliacaoService.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Este registro esta vinculado a um evento, não e possivel excluir.");
            }
        }

        public IEnumerable<AvaliacaoViewModel> GetAll()
        {
            return m_AvaliacaoService.GetAll().Select(item => new AvaliacaoViewModel
            {
                Dtalteracao = item.DTALTERACAO,
                Dtcadastro = item.DTCADASTRO,
                Descricao = item.DESCRICAO,
                Disponivel = item.DISPONIVEL,
                Dtinicio = item.DTINICIO ?? DateTime.Now,
                Dttermino = item.DTTERMINO ?? DateTime.Now,
                Eventoid = item.EVENTOID,
                Horainicio = item.HORAINICIO,
                Horatermino = item.HORATERMINO,
                Id = item.ID,
                Titulo = item.TITULO,
            });
        }

        public AvaliacaoViewModel GetById(int id)
        {
            var item = m_AvaliacaoService.GetById(id);
            if (item != null)
            {
                return new AvaliacaoViewModel
                {
                    Dtalteracao = item.DTALTERACAO,
                    Descricao = item.DESCRICAO,
                    Disponivel = item.DISPONIVEL,
                    Dtinicio = item.DTINICIO ?? DateTime.Now,
                    Dttermino = item.DTTERMINO ?? DateTime.Now,
                    Eventoid = item.EVENTOID,
                    Horainicio = item.HORAINICIO,
                    Horatermino = item.HORATERMINO,
                    Id = item.ID,
                    Titulo = item.TITULO
                };
            }
            return new AvaliacaoViewModel();
        }

        public int Update(AvaliacaoViewModel entity)
        {
            if (entity.Eventoid <= 0) throw new Exception("Favor informe um evento.");

            var item = m_AvaliacaoService.GetById(entity.Id);
            if (item != null)
            {
                item.DTALTERACAO = DateTime.Now;
                item.DESCRICAO = entity.Descricao;
                item.DISPONIVEL = entity.Disponivel;
                item.DTINICIO = entity.Dtinicio;
                item.DTTERMINO = entity.Dttermino;
                item.EVENTOID = entity.Eventoid;
                item.HORAINICIO = entity.Horainicio;
                item.HORATERMINO = entity.Horatermino;
                item.TITULO = entity.Titulo;
                m_AvaliacaoService.Update(item);
            }
            return m_AvaliacaoService.Commit();
        }
    }
}