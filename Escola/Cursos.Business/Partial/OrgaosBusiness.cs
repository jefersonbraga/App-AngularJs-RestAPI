using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;
namespace Cursos.Business
{
    public partial class OrgaosBusiness : IOrgaosBusiness
    {
        public int Add(OrgaosViewModel entity)
        {
            m_OrgaosService.Add(new Data.AD_ORGAOS {
                ID = entity.Id,
                IDORGAOANTIGO = entity.Idorgaoantigo,
                ORGAO = entity.Orgao,
            });
            return m_OrgaosService.Commit();
        }

        public int Delete(OrgaosViewModel entity)
        {
            var item = m_OrgaosService.GetById(entity.Id);
            if (item != null)
            {
                m_OrgaosService.Delete(item);
            }
            return m_OrgaosService.Commit();
        }

        public IEnumerable<OrgaosViewModel> GetAll()
        {
            return m_OrgaosService.GetAll().Select(item => new OrgaosViewModel
            {
                Id = item.ID,
                Idorgaoantigo = item.IDORGAOANTIGO ?? 0,
                Orgao = item.ORGAO,
            });
        }

        public OrgaosViewModel GetById(int id)
        {
            var item = m_OrgaosService.GetById(id);
            if (item != null)
            {
                return new OrgaosViewModel
                {
                    Id = item.ID,
                    Idorgaoantigo = item.IDORGAOANTIGO ?? 0,
                    Orgao = item.ORGAO,
                    
                };

            }
            return new OrgaosViewModel();
        }

        public int Update(OrgaosViewModel entity)
        {
            var item = m_OrgaosService.GetById(entity.Id);
            if (item != null)
            {
                item.IDORGAOANTIGO = entity.Idorgaoantigo;
                item.ORGAO = entity.Orgao;
                m_OrgaosService.Update(item);
            }
            
            return m_OrgaosService.Commit();
        }
    }
}
