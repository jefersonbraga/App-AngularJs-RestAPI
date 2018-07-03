
using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.Data;
using Cursos.ViewModel;
namespace Cursos.Business
{
    public partial class AcoesBusiness : IAcoesBusiness
    {
        public int Add(AcoesViewModel entity)
        {
            m_AcoesService.Add(new AD_ACOES {
                ACOES = entity.Acoes,
                ICONE = entity.Icone,
                LINK = entity.Link,
                MODULOID = entity.Moduloid,
                ORDEM = entity.Ordem,
            });

            return m_AcoesService.Commit();
        }
        

        public int Delete(AcoesViewModel entity)
        {
            var acoes = m_AcoesService.GetById(entity.Id);
            if (acoes != null)
                m_AcoesService.Delete(acoes);

            return m_AcoesService.Commit();
        }

        public IEnumerable<AcoesViewModel> GetAll()
        {
            return m_AcoesService.GetAll().Select(item => new AcoesViewModel {
                Id = item.ID,
                Acoes = item.ACOES,
                Icone = item.ICONE,
                Link = item.LINK,
                Moduloid = item.MODULOID,
                Ordem = item.ORDEM ?? 0,
            });
        }

        public AcoesViewModel GetById(int id)
        {
            var item = m_AcoesService.GetById(id);
            if (item != null)
            {
                return new AcoesViewModel
                {
                    Id = item.ID,
                    Acoes = item.ACOES,
                    Icone = item.ICONE,
                    Link = item.LINK,
                    Moduloid = item.MODULOID,
                    Ordem = item.ORDEM ?? 0,
                };
            }

            return null;
        }

        public int Update(AcoesViewModel entity)
        {
            var item = m_AcoesService.GetById(entity.Id);
            if (item != null)
            {
                item.ACOES = entity.Acoes;
                item.ICONE = entity.Icone;
                item.LINK = entity.Link;
                item.MODULOID = entity.Moduloid;
                item.ORDEM = entity.Ordem;

                m_AcoesService.Update(item);
            }

            return m_AcoesService.Commit();
        }
    }
}
