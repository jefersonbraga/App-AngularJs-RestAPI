using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class UfBusiness : IUfBusiness
    {
        public int Add(UfViewModel entity)
        {
            throw new NotImplementedException("Esta entidade nao permite insersao de dados!");
        }

        public int Delete(UfViewModel entity)
        {
            throw new NotImplementedException("Esta entidade nao permite deletar dados");
        }

        public IEnumerable<UfViewModel> GetAll()
        {
            return m_UfService.GetAll().Select(item=> new UfViewModel {
                Nopais = item.NO_PAIS,
                Noregiao = item.NO_REGIAO,
                Nouf = item.NO_UF,
                Sguf = item.SG_UF
            });
        }

        public UfViewModel GetById(int id)
        {
            throw new NotImplementedException("Esta entidade nao tem busca por id do tipo inteiro");
        }

        public UfViewModel GetByUf(string uf)
        {
            var item = m_UfService.GetAll().Where(x => x.SG_UF == uf).FirstOrDefault();
            if (item != null)
            {
                return new UfViewModel
                {
                    Nopais = item.NO_PAIS,
                    Noregiao = item.NO_REGIAO,
                    Nouf = item.NO_UF,
                    Sguf = item.SG_UF
                };
            }
            return new UfViewModel();
        }

        public int Update(UfViewModel entity)
        {
            throw new NotImplementedException("Esta entidade nao permite atualizar dados");
        }
    }
}
