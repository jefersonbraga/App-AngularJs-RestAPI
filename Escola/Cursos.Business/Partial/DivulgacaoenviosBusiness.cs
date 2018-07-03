using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class DivulgacaoenviosBusiness : IDivulgacaoenviosBusiness
    {
        public int Add(DivulgacaoenviosViewModel entity)
        {
            var divulgacao = new Data.EV_DIVULGACAOENVIOS
            {
                ASSUNTO = entity.Assunto,
                IDORGAOTRABALHO = entity.Idorgaotrabalho,
                DSLETRAALFABETO = entity.Dsletraalfabeto,
                DTALTERACAO = DateTime.Now,
                DTCADASTRO = DateTime.Now,
                EMAILTESTE = entity.Emailteste,
                IDDIVULGACAO = entity.Iddivulgacao,
                EMAILREMETENTE = entity.Emailremetente,
            };

            if (entity.Idevento != 0)
                divulgacao.IDEVENTO = entity.Idevento;
            if (entity.Idorgaotrabalho != 0)
                divulgacao.IDORGAOTRABALHO = entity.Idorgaotrabalho;

            m_DivulgacaoenviosService.Add(divulgacao);

            return m_DivulgacaoenviosService.Commit();
        }

        public int Delete(DivulgacaoenviosViewModel entity)
        {
            var item = m_DivulgacaoenviosService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_DivulgacaoenviosService.Update(item);

            }

            return m_DivulgacaoenviosService.Commit();
        }

        public IEnumerable<DivulgacaoenviosViewModel> GetAll()
        {
            return m_DivulgacaoenviosService.GetAll().Select(item => new DivulgacaoenviosViewModel
            {
                Id = item.ID,
                Assunto = item.ASSUNTO,
                Dsletraalfabeto = item.DSLETRAALFABETO,
                Dtalteracao = item.DTALTERACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Emailremetente = item.EMAILREMETENTE,
                Emailteste = item.EMAILTESTE,
                Iddivulgacao = item.IDDIVULGACAO,
                Idevento = item.IDEVENTO.HasValue ? item.IDEVENTO.Value : 0,
                Idorgaotrabalho = item.IDORGAOTRABALHO.HasValue ? item.IDORGAOTRABALHO.Value : 0
            });
        }

        public DivulgacaoenviosViewModel GetById(int id)
        {
            var item = m_DivulgacaoenviosService.GetById(id);
            if (item != null)
            {
                return new DivulgacaoenviosViewModel
                {
                    Id = item.ID,
                    Assunto = item.ASSUNTO,
                    Dsletraalfabeto = item.DSLETRAALFABETO,
                    Dtalteracao = item.DTALTERACAO,
                    Dtcadastro = item.DTCADASTRO,
                    Dtexclusao = item.DTEXCLUSAO,
                    Emailremetente = item.EMAILREMETENTE,
                    Emailteste = item.EMAILTESTE,
                    Iddivulgacao = item.IDDIVULGACAO,
                    Idevento = item.IDEVENTO.HasValue ? item.IDEVENTO.Value : 0,
                    Idorgaotrabalho = item.IDORGAOTRABALHO.HasValue ? item.IDORGAOTRABALHO.Value : 0
                };
            }
            return new DivulgacaoenviosViewModel();
        }

        public int Update(DivulgacaoenviosViewModel entity)
        {
            var item = m_DivulgacaoenviosService.GetById(entity.Id);
            if (item != null)
            {
                item.ASSUNTO = entity.Assunto;
                item.DSLETRAALFABETO = entity.Dsletraalfabeto;
                item.DTALTERACAO = entity.Dtalteracao;
                item.DTEXCLUSAO = DateTime.Now;
                item.EMAILREMETENTE = entity.Emailremetente;
                item.EMAILTESTE = entity.Emailteste;
                item.IDDIVULGACAO = entity.Iddivulgacao;
                item.IDEVENTO = entity.Idevento;
                item.IDORGAOTRABALHO = entity.Idorgaotrabalho;

                m_DivulgacaoenviosService.Update(item);
            }
            return m_DivulgacaoenviosService.Commit();
        }
    }
}