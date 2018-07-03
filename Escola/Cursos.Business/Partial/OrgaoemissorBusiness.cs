using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;


namespace Cursos.Business
{
    public partial class OrgaoemissorBusiness : IOrgaoemissorBusiness
    {
        public int Add(OrgaoemissorViewModel entity)
        {
            throw new NotImplementedException("Esta entidade nao permite inserir dados");
        }

        public int Delete(OrgaoemissorViewModel entity)
        {
            throw new NotImplementedException("Esta entidade nao permite deletar dados");
        }

        public IEnumerable<OrgaoemissorViewModel> GetAll()
        {
            return m_OrgaoemissorService.GetAll().Select(item => new OrgaoemissorViewModel {
                Coemissor = item.CO_EMISSOR,
                Noemissor = item.NO_EMISSOR
            });
        }

        public OrgaoemissorViewModel GetById(int id)
        {
            throw new NotImplementedException("Esta entidade nao tem consulta por id do tipo inteiro");
        }

        public OrgaoemissorViewModel GetByOrgao(string orgao)
        {
            return m_OrgaoemissorService.GetAll().Where(x=>x.CO_EMISSOR == orgao).Select(item => new OrgaoemissorViewModel
            {
                Coemissor = item.CO_EMISSOR,
                Noemissor = item.NO_EMISSOR
            }).FirstOrDefault();
        }

        public int Update(OrgaoemissorViewModel entity)
        {
            throw new NotImplementedException("Esta entidade nao permite atualizacao de dados");
        }
    }
}
