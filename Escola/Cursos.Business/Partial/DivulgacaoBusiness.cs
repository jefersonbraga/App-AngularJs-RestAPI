
using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;
namespace Cursos.Business
{
    public partial class DivulgacaoBusiness : IDivulgacaoBusiness
    {
        public int Add(DivulgacaoViewModel entity)
        {
            m_DivulgacaoService.Add(new Data.EV_DIVULGACAO {
                MENSAGEM = entity.Mensagem,
                DTCRIACAO = DateTime.Now,
                DTALTERACAO = DateTime.Now,
                TITULO = entity.Titulo
            });

            return m_DivulgacaoService.Commit();
        }

        public int Delete(DivulgacaoViewModel entity)
        {
            var item = m_DivulgacaoService.GetById(entity.Id);
            if (item != null)
            {
                m_DivulgacaoService.Delete(item);
            }
            return m_DivulgacaoService.Commit();
        }

        public IEnumerable<DivulgacaoViewModel> GetAll()
        {
            return m_DivulgacaoService.GetAll().Select(item => new DivulgacaoViewModel {
                Mensagem = item.MENSAGEM,
                Dtalteracao = item.DTCRIACAO,
                Dtcriacao = item.DTCRIACAO,
                Titulo = item.TITULO,
                Id = item.ID
            });
        }

        public DivulgacaoViewModel GetById(int id)
        {
            var item = m_DivulgacaoService.GetById(id);
            if (item != null)
            {
                return new DivulgacaoViewModel
                {
                    Mensagem = item.MENSAGEM,
                    Dtalteracao = item.DTCRIACAO,
                    Dtcriacao = item.DTCRIACAO,
                    Titulo = item.TITULO,
                    Id = item.ID
                };
            }
            return new DivulgacaoViewModel();
        }

        public int Update(DivulgacaoViewModel entity)
        {
            var item = m_DivulgacaoService.GetById(entity.Id);
            if (item != null)
            {
                item.MENSAGEM = entity.Mensagem;
                item.DTALTERACAO = entity.Dtcriacao;
                item.TITULO = entity.Titulo;
                m_DivulgacaoService.Update(item);
            }

            return m_DivulgacaoService.Commit();
        }
    }
}
