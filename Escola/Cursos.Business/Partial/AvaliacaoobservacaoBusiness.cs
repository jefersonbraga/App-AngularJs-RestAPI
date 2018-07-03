using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class AvaliacaoobservacaoBusiness : IAvaliacaoobservacaoBusiness
    {
        public int Add(AvaliacaoobservacaoViewModel entity)
        {
            if (entity.Avaliacaoid <= 0) throw new Exception("Favor informe uma avaliação.");
            if (entity.Clienteid <= 0) throw new Exception("Favor informe um cliente.");

            m_AvaliacaoobservacaoService.Add(new Data.EV_AVALIACAOOBSERVACAO
            {
                DTATUALIZACAO = DateTime.Now,
                DTCADASTRO = DateTime.Now,
                AVALIACAOID = entity.Avaliacaoid,
                OBSERVACAO = entity.Observacao,
                CLIENTEID = entity.Clienteid,
            });
            return m_AvaliacaoobservacaoService.Commit();
        }

        public int Delete(AvaliacaoobservacaoViewModel entity)
        {
            var item = m_AvaliacaoobservacaoService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_AvaliacaoobservacaoService.Update(item);
            }
            return m_AvaliacaoobservacaoService.Commit();
        }

        public IEnumerable<AvaliacaoobservacaoViewModel> GetAll()
        {
            return m_AvaliacaoobservacaoService.GetAll().Select(item => new AvaliacaoobservacaoViewModel
            {
                Id = item.ID,
                Avaliacaoid = item.AVALIACAOID,
                Clienteid = item.CLIENTEID,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = DateTime.Now,
                Dtexclusao = DateTime.Now,
                Observacao = item.OBSERVACAO,
            });
        }

        public AvaliacaoobservacaoViewModel GetById(int id)
        {
            var item = m_AvaliacaoobservacaoService.GetById(id);
            if (item != null)
            {
                return new AvaliacaoobservacaoViewModel
                {
                    Id = item.ID,
                    Avaliacaoid = item.AVALIACAOID,
                    Clienteid = item.CLIENTEID,
                    Dtatualizacao = DateTime.Now,
                    Dtcadastro = DateTime.Now,
                    Dtexclusao = item.DTEXCLUSAO,
                    Observacao = item.OBSERVACAO,
                };
            }
            return new AvaliacaoobservacaoViewModel();
        }

        public int Update(AvaliacaoobservacaoViewModel entity)
        {
            if (entity.Avaliacaoid <= 0) throw new Exception("Favor informe uma avaliação.");
            if (entity.Clienteid <= 0) throw new Exception("Favor informe um cliente.");
            var item = m_AvaliacaoobservacaoService.GetById(entity.Id);
            if (item != null)
            {
                item.AVALIACAOID = entity.Avaliacaoid;
                item.CLIENTEID = entity.Clienteid;
                item.DTATUALIZACAO = DateTime.Now;
                item.OBSERVACAO = entity.Observacao;

                m_AvaliacaoobservacaoService.Update(item);
            }
            return m_AvaliacaoobservacaoService.Commit();
        }
    }
}