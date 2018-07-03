using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class MunicipioBusiness : IMunicipioBusiness
    {
        public int Add(MunicipioViewModel entity)
        {
            throw new NotImplementedException("Entidade nao permite inserir dados");
        }

        public int Delete(MunicipioViewModel entity)
        {
            throw new NotImplementedException("Entidade nao permite excluir dados");
        }

        public IEnumerable<MunicipioViewModel> GetAll()
        {
            return m_MunicipioService.GetAll().Select(item => new MunicipioViewModel {
                Coddd = item.CO_DDD,
                Nomunicipio = item.NO_MUNICIPIO,
                Numunicipio = item.NU_MUNICIPIO,
                Sguf = item.SG_UF
            });
        }

        public MunicipioViewModel GetById(int id)
        {
            throw new NotImplementedException("Entidade nao permite consultar pela pk");
        }

        public IEnumerable<MunicipioViewModel> GetContains(string term)
        {
            var teste = m_MunicipioService.GetAll().Where(x => x.NO_MUNICIPIO.StartsWith(term));

            return m_MunicipioService.GetAll().Select(item => new MunicipioViewModel
            {
                Coddd = item.CO_DDD,
                Nomunicipio = item.NO_MUNICIPIO,
                Numunicipio = item.NU_MUNICIPIO,
                Sguf = item.SG_UF
            }).Where(x=> x.Nomunicipio.ToLower().StartsWith(term.ToLower()));
        }

        public int Update(MunicipioViewModel entity)
        {
            throw new NotImplementedException("Entidade nao permite atualizar dados");
        }
    }
}
