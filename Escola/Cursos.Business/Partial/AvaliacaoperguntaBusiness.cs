using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class AvaliacaoperguntaBusiness : IAvaliacaoperguntaBusiness
    {
        public int Add(AvaliacaoperguntaViewModel entity)
        {
            if (entity.Avaliacaoid <= 0) throw new Exception("Favor informe uma avaliação.");

            m_AvaliacaoperguntaService.Add(new Data.EV_AVALIACAOPERGUNTA
            {
                //ID = entity.Id, NUNCA PASSA CHAVE PRIMARIA PARA PODER ADCIONAR NO CASO DO TIPO IDENTITY
                AVALIACAOID = entity.Avaliacaoid,
                DTATUALIZACAO = DateTime.Now,
                DTCADASTRO = DateTime.Now,
                ORDEM = entity.Ordem,
                TITULO = entity.Titulo,
            });
            return m_AvaliacaoperguntaService.Commit();
        }

        public int Delete(AvaliacaoperguntaViewModel entity)
        {
            var item = m_AvaliacaoperguntaService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_AvaliacaoperguntaService.Update(item);
            }
            return m_AvaliacaoperguntaService.Commit();
        }

        public IEnumerable<AvaliacaoperguntaViewModel> GetAll()
        {
            var consulta = m_AvaliacaoperguntaService.GetAll();
            return consulta.Select(item => new AvaliacaoperguntaViewModel
            {
                Id = item.ID,
                Avaliacaoid = item.AVALIACAOID,
                Dtatualizacao = DateTime.Now,
                Dtcadastro = DateTime.Now,
                Dtexclusao = DateTime.Now,
                Ordem = item.ORDEM,
                Titulo = item.TITULO
            });
        }

        public AvaliacaoperguntaViewModel GetById(int id)
        {
            var item = m_AvaliacaoperguntaService.GetById(id);
            if (item != null)
            {
                return new AvaliacaoperguntaViewModel
                {
                    Id = item.ID,
                    Titulo = item.TITULO,
                    Ordem = item.ORDEM,
                    Dtexclusao = DateTime.Now,
                    Avaliacaoid = item.AVALIACAOID,
                    Dtatualizacao = DateTime.Now,
                    Dtcadastro = DateTime.Now,
                };
            }
            return new AvaliacaoperguntaViewModel();
        }

        public int Update(AvaliacaoperguntaViewModel entity)
        {
            if (entity.Avaliacaoid <= 0) throw new Exception("Favor informe uma avaliação.");

            var item = m_AvaliacaoperguntaService.GetById(entity.Id);
            if (item != null)
            {
                item.AVALIACAOID = entity.Avaliacaoid;
                item.DTATUALIZACAO = DateTime.Now;
                item.TITULO = entity.Titulo;
                item.ORDEM = entity.Ordem;
                m_AvaliacaoperguntaService.Update(item);
            }
            return m_AvaliacaoperguntaService.Commit();
        }
    }
}