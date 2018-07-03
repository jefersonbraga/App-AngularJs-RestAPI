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
    public partial class LocalprovaBusiness : ILocalprovaBusiness
    {
        public int Add(LocalprovaViewModel entity)
        {
            m_LocalprovaService.Add(new Data.EV_LOCALPROVA  {
                BAIRRO = entity.Bairro,
                CEP = entity.Cep,
                CIDADE = entity.Cidade,
                COMPLEMENTO = entity.Complemento,
                ENDERECO = entity.Endereco,
                ESTADO = entity.Estado,
                ID = entity.Id,
                LOCAL = entity.Local,
                LOGRADOURO = entity.Endereco,
                NUMERO = entity.Numero,
            });
            return m_LocalprovaService.Commit();
        }

        public int Delete(LocalprovaViewModel entity)
        {
            var item = m_LocalprovaService.GetById(entity.Id);
            if (item != null)
            {
                m_LocalprovaService.Delete(item);
            }
            return m_LocalprovaService.Commit();
        }   

        public IEnumerable<LocalprovaViewModel> GetAll()
        {
            return m_LocalprovaService.GetAll().Select(item => new LocalprovaViewModel {
                Bairro = item.BAIRRO,
                Cep = item.CEP,
                Cidade = item.CIDADE,
                Complemento = item.COMPLEMENTO,
                Endereco = item.ENDERECO,
                Estado = item.ESTADO,
                Id = item.ID,
                Local = item.LOCAL,
                Logradouro = item.LOGRADOURO,
                Numero = item.NUMERO ?? 0,
            });
        }

        public LocalprovaViewModel GetById(int id)
        {
            var item = m_LocalprovaService.GetById(id);
            if (item != null)
            {
                return new LocalprovaViewModel
                {
                    Bairro = item.BAIRRO,
                    Cep = item.CEP,
                    Cidade = item.CIDADE,
                    Complemento = item.COMPLEMENTO,
                    Endereco = item.ENDERECO,
                    Estado = item.ESTADO,
                    Id = item.ID,
                    Local = item.LOCAL,
                    Logradouro = item.LOGRADOURO,
                    Numero = item.NUMERO ?? 0,
                };
            }
            return new LocalprovaViewModel();
        }   

        public int Update(LocalprovaViewModel entity)
        {
            var item = m_LocalprovaService.GetById(entity.Id);
            if (item != null)
            {
                item.BAIRRO = entity.Bairro;
                item.CEP = entity.Cep;
                item.CIDADE = entity.Cidade;
                item.COMPLEMENTO = entity.Complemento;
                item.ENDERECO = entity.Endereco;
                item.ESTADO = entity.Estado;
                item.LOCAL = entity.Local;
                item.LOGRADOURO = entity.Logradouro;
                item.NUMERO = entity.Numero;
                m_LocalprovaService.Update(item);
            }
            
            return m_LocalprovaService.Commit();
        }
    }
}
