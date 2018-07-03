///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 9/14/2017 12:38:07 PM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class EscolaridadeBusiness : IEscolaridadeBusiness
    {
        private object item;

        public int Add(EscolaridadeViewModel entity)
        {
            m_EscolaridadeService.Add(new Data.EV_ESCOLARIDADE
            {
                ESCOLARIDADE = entity.Escolaridade,
                IDESCOLARIDADEANTIGO = entity.Idescolaridadeantigo
            });
            return m_EscolaridadeService.Commit();
        }

        public int Delete(EscolaridadeViewModel entity)
        {
            var item = m_EscolaridadeService.GetById(entity.Id);
            if (item != null)
            {
                m_EscolaridadeService.Delete(item);
            }
            return m_EscolaridadeService.Commit();
        }

        public IEnumerable<EscolaridadeViewModel> GetAll()
        {
            return m_EscolaridadeService.GetAll().Select(item => new EscolaridadeViewModel
            {
                Escolaridade = item.ESCOLARIDADE,
                Id = item.ID,
                Idescolaridadeantigo = item.IDESCOLARIDADEANTIGO
            });
        }

        public EscolaridadeViewModel GetById(int id)
        {
            var item = m_EscolaridadeService.GetById(id);
            if (item != null)
            {
                return new EscolaridadeViewModel
                {
                    Escolaridade = item.ESCOLARIDADE,
                    Id = item.ID,
                    Idescolaridadeantigo = item.IDESCOLARIDADEANTIGO
                };
            }
            return new EscolaridadeViewModel();
        }

        public int Update(EscolaridadeViewModel entity)
        {
            var item = m_EscolaridadeService.GetById(entity.Id);
            if (item != null)
            {
                item.ESCOLARIDADE = entity.Escolaridade;
                item.IDESCOLARIDADEANTIGO = entity.Idescolaridadeantigo;
                m_EscolaridadeService.Update(item);
            }

            return m_EscolaridadeService.Commit();
        }
    }
}