using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class QuestoescorrecaoBusiness : IQuestoescorrecaoBusiness
    {
        public int Add(QuestoescorrecaoViewModel entity)
        {
            m_QuestoescorrecaoService.Add(new Data.EV_QUESTOESCORRECAO
            {
                DESCRICAO = entity.Descricao,
                DTATUALIZACAO = DateTime.Now,
                DTCADASTRO = DateTime.Now,
                DTEXCLUSAO = DateTime.Now,
                GRUPOQUESTOESID = entity.Grupoquestoesid,
            });

            return m_QuestoescorrecaoService.Commit();
        }

        public int Delete(QuestoescorrecaoViewModel entity)
        {
            var item = m_QuestoescorrecaoService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_QuestoescorrecaoService.Update(item);
            }
            return m_QuestoescorrecaoService.Commit();
        }

        public IEnumerable<QuestoescorrecaoViewModel> GetAll()
        {
            return m_QuestoescorrecaoService.GetAll().Select(item => new QuestoescorrecaoViewModel
            {
                //Isto e um select da forma que esta pegando a data sempre vai ser a corrente e nao a que foi salva.
                Descricao = item.DESCRICAO,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Grupoquestoesid = item.GRUPOQUESTOESID,
                Id = item.ID
            });
        }

        public QuestoescorrecaoViewModel GetById(int id)
        {
            var item = m_QuestoescorrecaoService.GetById(id);
            if (item != null)
            {
                return new QuestoescorrecaoViewModel
                {
                    Descricao = item.DESCRICAO,
                    Id = item.ID,
                    Grupoquestoesid = item.GRUPOQUESTOESID,
                    Dtatualizacao = item.DTATUALIZACAO,
                    Dtcadastro = item.DTCADASTRO,
                    Dtexclusao = item.DTEXCLUSAO,
                };
            }
            return new QuestoescorrecaoViewModel();
        }

        public int Update(QuestoescorrecaoViewModel entity)
        {
            var item = m_QuestoescorrecaoService.GetById(entity.Id);
            if (item != null)
            {
                item.DESCRICAO = entity.Descricao;
                item.DTATUALIZACAO = DateTime.Now;
                item.GRUPOQUESTOESID = entity.Grupoquestoesid;
                m_QuestoescorrecaoService.Update(item);
            }

            return m_QuestoescorrecaoService.Commit();
        }
    }
}