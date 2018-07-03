using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.Data;
using Cursos.Repository.Services;
using Cursos.Repository.Services.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class InscricaoBusiness : IInscricaoBusiness
    {
        private readonly IClienteService m_ClienteService;
        private readonly IEventoService m_EventoService;
        private readonly ISalalocalprovaService m_SalalocalprovaService;
        private readonly ILocaleventoService m_LocaleventoService;

        /// <summary>
        /// Construtor Object Class EV_INSCRICAO
        /// </summary>
        /// <param name="context">context database</param>
        public InscricaoBusiness(IInscricaoService pInscricaoService, IClienteService pClienteService,
            IEventoService pEventoService, ISalalocalprovaService pSalalocalprovaService, ILocaleventoService localeventoService)
        {
            m_InscricaoService = pInscricaoService;
            m_ClienteService = pClienteService;
            m_EventoService = pEventoService;
            m_SalalocalprovaService = pSalalocalprovaService;
            m_LocaleventoService = localeventoService;
        }

        public int Add(InscricaoViewModel entity)
        {
            m_InscricaoService.Add(new Data.EV_INSCRICAO
            {
                BAIXA = entity.Baixa,
                BOLETOEMITIDO = entity.Boletoemitido,
                CLIENTEID = entity.Clienteid,
                CRIADO = entity.Criado,
                DATAPAGAMENTO = entity.Datapagamento,
                DTBOLETOEMITIDO = entity.Dtboletoemitido,
                DTINSCRICAO = entity.Dtinscricao,
                EVENTOID = entity.Eventoid,
                FORMAPAGAMENTO = entity.Formapagamento,
                ID = entity.Id,
                PAGO = entity.Pago,
                TURNO = entity.Turno,
                VALOR = entity.Valor,
                VALORRECEBIDO = entity.Valorrecebido,
            });
            return m_InscricaoService.Commit();
        }

        public int Delete(InscricaoViewModel entity)
        {
            var item = m_InscricaoService.GetById(entity.Id);
            if (item != null)
            {
                item.DTEXCLUSAO = DateTime.Now;
                m_InscricaoService.Update(item);
            }
            return m_InscricaoService.Commit();
        }

        public IEnumerable<InscricaoViewModel> GetTopInscricoes()
        {
            var inscricao = m_InscricaoService.GetInscricaoPaginacao("asc", 0, 10).ToList();
            return inscricao.Select(item => ConvertToInscricaoViewModel(item)).ToList();
        }

        public IEnumerable<InscricaoViewModel> GetAll()
        {
            var inscricao = m_InscricaoService.GetAll().ToList();
            return inscricao.Select(item => ConvertToInscricaoViewModel(item)).ToList();
        }

        public IEnumerable<InscricaoViewModel> GetByClientId(int id)
        {
            var inscricao = m_InscricaoService.GetInscricaoByClienteId(id);
            return inscricao.Select(item => ConvertToInscricaoViewModel(item));
        }

        public InscricaoViewModel GetById(int id)
        {
            var item = m_InscricaoService.GetById(id);
            if (item != null) return ConvertToInscricaoViewModel(item);

            return new InscricaoViewModel();
        }

        public int Update(InscricaoViewModel entity)
        {
            var item = m_InscricaoService.GetById(entity.Id);
            if (item != null)
            {
                item.BAIXA = entity.Baixa;
                //item.BOLETOEMITIDO = entity.Boletoemitido;
                //item.CLIENTEID = entity.Clienteid;
                item.CRIADO = entity.Criado;
                item.DATAPAGAMENTO = entity.Datapagamento;
                //item.DTBOLETOEMITIDO = entity.Dtboletoemitido;
                //item.DTINSCRICAO = entity.Dtinscricao;
                //item.EVENTOID = entity.Eventoid;
                item.FORMAPAGAMENTO = entity.Formapagamento;
                item.PAGO = entity.Pago;
                item.TURNO = entity.Turno;
                item.VALOR = entity.Valor;
                //item.VALORRECEBIDO = entity.Valorrecebido;
                m_InscricaoService.Update(item);
            }
            return m_InscricaoService.Commit();
        }

        public PaginacaoInscricao GetInscricaoPaginacao(string order, int offset, int limit)
        {
            var total = m_InscricaoService.GetTotalRegistros();
            var dataInscricao = m_InscricaoService.GetInscricaoPaginacao(order, offset, limit).Select(item => ConvertToInscricaoViewModel(item));

            return new PaginacaoInscricao { total = total, rows = dataInscricao };
        }

        private InscricaoViewModel ConvertToInscricaoViewModel(EV_INSCRICAO item)
        {
            var inscricao = new InscricaoViewModel
            {
                Baixa = item.BAIXA,
                Boletoemitido = item.BOLETOEMITIDO,
                Clienteid = item.CLIENTEID,
                Criado = item.CRIADO ?? DateTime.Now,
                Datapagamento = item.DATAPAGAMENTO ?? DateTime.Now,
                Dtboletoemitido = item.DTBOLETOEMITIDO ?? DateTime.Now,
                Dtinscricao = item.DTINSCRICAO,
                Eventoid = item.EVENTOID,
                Formapagamento = item.FORMAPAGAMENTO,
                Id = item.ID,
                Pago = item.PAGO,
                Turno = item.TURNO,
                Valor = item.VALOR,
                Valorrecebido = item.VALORRECEBIDO ?? 0,
                NomeCliente = item.EV_CLIENTE.NOME,
                Aluno = new AlunoViewModel
                {
                    Nome = item.EV_CLIENTE.NOME,
                    Bairro = item.EV_CLIENTE.BAIRRO,
                    Celular = item.EV_CLIENTE.TEL_CELULAR,
                    Telefone = item.EV_CLIENTE.TEL_RESIDENCIAL,
                    CEP = item.EV_CLIENTE.CEP,
                    Cidade = item.EV_CLIENTE.CIDADE,
                    Complemento = item.EV_CLIENTE.COMPLEMENTO,
                    CPF = item.EV_CLIENTE.CPF,
                    Dtnascimento = item.EV_CLIENTE.DTNASCIMENTO,
                    Email = item.EV_CLIENTE.EMAIL,
                    Logradouro = item.EV_CLIENTE.ENDERECO,
                    Numero = item.EV_CLIENTE.NUMERO,
                    RG = item.EV_CLIENTE.RG,
                    UF = item.EV_CLIENTE.ESTADO,
                    Sexo = item.EV_CLIENTE.SEXO
                },
                Evento = item.EV_EVENTO.NOME,
                Evento1 = new EventoViewModel1
                {
                    Nome = item.EV_EVENTO.NOME,
                    Dtevento = item.EV_EVENTO.DTINICIO,
                    Horainicio = item.EV_EVENTO.HORAINICIO,
                    Horatermino = item.EV_EVENTO.HORATERMINO,
                    Localevento = item.EV_EVENTO.EV_LOCALEVENTO.DESCRICAO
                },
                Dtalteracao = item.DTALTERACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                Dtpagamento = item.DATAPAGAMENTO.HasValue ? item.DATAPAGAMENTO.Value.ToString("dd/MM/yyyy") : "Sem informação"
            };
            return inscricao;
        }

        public PaginacaoInscricao GetInscricaoPaginacao(string search, string order, int offset, int limit)
        {
            var total = m_InscricaoService.GetTotalRegistros(search);
            var dataInscricao = m_InscricaoService.GetInscricaoPaginacao(search, order, offset, limit).Select(item => ConvertToInscricaoViewModel(item));

            return new PaginacaoInscricao { total = total, rows = dataInscricao };
        }
    }
}