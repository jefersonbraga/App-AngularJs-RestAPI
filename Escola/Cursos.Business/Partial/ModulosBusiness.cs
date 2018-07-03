using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;
namespace Cursos.Business
{
    public partial class ModulosBusiness : IModulosBusiness
    {
        public int Add(ModulosViewModel entity)
        {
            m_ModulosService.Add(new Data.AD_MODULOS {
               ID = entity.Id,
               MODULO = entity.Modulo,
            });

            return m_ModulosService.Commit();
        }

        public int Delete(ModulosViewModel entity)
        {
            var item = m_ModulosService.GetById(entity.Id);
            if (item != null)
            {
                m_ModulosService.Delete(item);
            }
            return m_ModulosService.Commit();
        }

        public IEnumerable<ModulosViewModel> GetAll()
        {
            return m_ModulosService.GetAll().Select(item => new ModulosViewModel{
               Id = item.ID,
               Modulo = item.MODULO
            });
        }

        public ModulosViewModel GetById(int id)
        {
            var item = m_ModulosService.GetById(id);
            if (item != null)
            {
                return new ModulosViewModel
                {
                    Id = item.ID,
                    Modulo = item.MODULO,
                };
            }
            return new ModulosViewModel();
        }

        public int Update(ModulosViewModel entity)
        {
            var item = m_ModulosService.GetById(entity.Id);
            if (item != null)
            {
                item.MODULO = entity.Modulo;
                m_ModulosService.Update(item);
            }
            
            return m_ModulosService.Commit();
        }
    }
}
