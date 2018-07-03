using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.Data;
using Cursos.ViewModel;
namespace Cursos.Business
{
    public partial class MenuBusiness : IMenuBusiness
    {
        public int Add(MenuViewModel entity)
        {
            m_MenuService.Add(new AD_MENU {
                ID = entity.Id,
                ACOESID = entity.Acoesid,
                LINK = entity.Link,
                MENU = entity.Menu,
                ORDEM = entity.Ordem,
                ATIVO = entity.Ativo
            });

            return m_MenuService.Commit();
        }

        public int Delete(MenuViewModel entity)
        {
            var item = m_MenuService.GetById(entity.Id);
            if (item != null)
            {
                m_MenuService.Delete(item);
            }
            return m_MenuService.Commit();
        }

        public IEnumerable<MenuViewModel> GetAll()
        {
            return m_MenuService.GetAll().Select(item=> new MenuViewModel {
                Id = item.ID,
                Acoesid = item.ACOESID,
                Link = item.LINK,
                Menu = item.MENU,
                Ordem = item.ORDEM ?? 0, 
                Ativo = item.ATIVO.HasValue ? item.ATIVO.Value : false
            }).Where(x=>x.Ativo == true);
        }

        public MenuViewModel GetById(int id)
        {
            var item = m_MenuService.GetById(id);
            if (item != null)
            {
                return new MenuViewModel
                {
                    Id = item.ID,
                    Acoesid = item.ACOESID,
                    Link = item.LINK,
                    Menu = item.MENU,
                    Ordem = item.ORDEM.Value,
                };
            }
            return new MenuViewModel();
        }

        public int Update(MenuViewModel entity)
        {
            var item = m_MenuService.GetById(entity.Id);
            if (item != null)
            {
                item.ACOESID = entity.Acoesid;
                item.LINK = entity.Link;
                item.MENU = entity.Menu;
                item.ORDEM = entity.Ordem;
                item.ATIVO = entity.Ativo;
                m_MenuService.Update(item);

            }
            
            return m_MenuService.Commit();
        }
    }
}
