using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class InstituicoesBusiness : IInstituicoesBusiness
    {
        public int Add(InstituicoesViewModel entity)
        {
            m_InstituicoesService.Add(new Data.ES_INSTITUICOES
            {
                NOME = entity.Nome,
                DTATUALIZACAO = DateTime.Now,
                DTCADASTRO = DateTime.Now,
                DPADMID = entity.Dpadmid,
                SIGLA = entity.Sigla,
                UF = entity.Uf
            });
            return m_InstituicoesService.Commit();
        }

        public int Delete(InstituicoesViewModel entity)
        {
            var item = m_InstituicoesService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_InstituicoesService.Update(item);
            }

            return m_InstituicoesService.Commit();
        }

        public IEnumerable<InstituicoesViewModel> GetAll()
        {
            return m_InstituicoesService.GetAll().Select(item => new InstituicoesViewModel
            {
                Dpadmid = item.DPADMID,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Id = item.ID,
                Nome = item.NOME,
                Sigla = item.SIGLA,
                Uf = item.UF
            });
        }

        public InstituicoesViewModel GetById(int id)
        {
            var item = m_InstituicoesService.GetById(id);
            if (item != null) return new InstituicoesViewModel();

            return new InstituicoesViewModel
            {
                Dpadmid = item.DPADMID,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Id = item.ID,
                Nome = item.NOME,
                Sigla = item.SIGLA,
                Uf = item.UF
            };
        }

        public int Update(InstituicoesViewModel entity)
        {
            var item = m_InstituicoesService.GetById(entity.Id);
            if (item != null)
            {
                item.SIGLA = entity.Sigla;
                item.NOME = entity.Nome;
                item.DPADMID = entity.Dpadmid;
                item.DTATUALIZACAO = DateTime.Now;
                item.UF = entity.Uf;
                m_InstituicoesService.Update(item);
            }

            return m_InstituicoesService.Commit();
        }
    }
}