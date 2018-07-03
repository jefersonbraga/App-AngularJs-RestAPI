using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class TemaBusiness : ITemaBusiness
    {
        public int Add(TemaViewModel entity)
        {
            m_TemaService.Add(new Data.EV_TEMA
            {
                TEMA = entity.Tema,
                DTATUALIZACAO = DateTime.Now,
                DTCADASTRO = DateTime.Now,
            });
            return m_TemaService.Commit();
        }

        public int Delete(TemaViewModel entity)
        {
            var item = m_TemaService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_TemaService.Update(item);
            }
            return m_TemaService.Commit();
        }

        public IEnumerable<TemaViewModel> GetAll()
        {
            return m_TemaService.GetAll().Select(item => new TemaViewModel
            {
                Id = item.ID,
                Tema = item.TEMA
            });
        }

        public TemaViewModel GetById(int id)
        {
            var item = m_TemaService.GetById(id);
            if (item != null)
            {
                return new TemaViewModel
                {
                    Id = item.ID,
                    Tema = item.TEMA
                };
            }
            return new TemaViewModel();
        }

        public int Update(TemaViewModel entity)
        {
            var item = m_TemaService.GetById(entity.Id);
            if (item != null)
            {
                item.TEMA = entity.Tema;
                item.DTATUALIZACAO = DateTime.Now;
                m_TemaService.Update(item);
            }

            return m_TemaService.Commit();
        }
    }
}