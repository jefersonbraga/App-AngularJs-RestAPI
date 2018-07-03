using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public class HomeBusiness : IHomeBusiness
    {
        private readonly IAcoesBusiness m_AcoesBusiness;
        private readonly IMenuBusiness m_MenuBusiness;

        public HomeBusiness(IAcoesBusiness acoesBusiness, IMenuBusiness menuBusiness)
        {
            m_AcoesBusiness = acoesBusiness;
            m_MenuBusiness = menuBusiness;
        }

        public IEnumerable<AcoesViewModel> GetMenu()
        {
            var listaAcoes = m_AcoesBusiness.GetAll().Where(x => x.Moduloid == 2).OrderBy(x => x.Ordem).ToList();
            foreach (var item in listaAcoes)
                item.Menu = m_MenuBusiness.GetAll().Where(m => m.Acoesid == item.Id).OrderBy(x => x.Ordem);

            return listaAcoes;
        }
    }
}