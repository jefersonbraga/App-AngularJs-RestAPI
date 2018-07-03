using ClosedXML.Excel;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Cursos.Business.Interfaces;
using Cursos.Data;
using Cursos.Repository.Services.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class ClienteBusiness : IClienteBusiness
    {
        private readonly IRefreshtokenService m_RefreshtokenServices;
        private readonly IEventoService m_EventoService;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ClienteBusiness(IClienteService clienteService, IRefreshtokenService refreshtokenService, IEventoService eventoService)
        {
            m_RefreshtokenServices = refreshtokenService;
            m_ClienteService = clienteService;
            m_EventoService = eventoService;
        }

        public int Add(ClienteViewModel entity)
        {
            if (m_ClienteService.FindBy(x => x.CPF.Equals(entity.Cpf)).Any()) throw new Exception("Cpf informado ja existe.");

            if (string.IsNullOrEmpty(entity.Orgaoemissor)) throw new Exception("Favor informar orgão emissor.");
            if (string.IsNullOrEmpty(entity.Ufemissor)) throw new Exception("Favor informar uf emissor.");
            if (entity.Orgaotrabalhoid <= 0) throw new Exception("Favor informar orgão de trabalho.");
            if (entity.Escolaridadeid <= 0) throw new Exception("Favor informar escolaridade.");
            //if (entity.Dtnascimento == null) throw new Exception("Favor informar data de nascimento.");

            if (entity.Dtemissao == null || entity.Dtemissao <= DateTime.MinValue) entity.Dtemissao = DateTime.Now;
            if (entity.Dtnascimento == null || entity.Dtnascimento < DateTime.MinValue) entity.Dtnascimento = DateTime.Now;
            var cliente = new EV_CLIENTE
            {
                USERID = entity.Userid,
                NOME = entity.Nome,
                EMAIL = entity.Email,
                RG = entity.Rg,
                ORGAOEMISSOR = entity.Orgaoemissor,
                UFEMISSOR = entity.Ufemissor,
                DTEMISSAO = entity.Dtemissao,
                CPF = entity.Cpf.Replace(".", "").Replace("/", "").Replace("-", ""),
                NACIONALIDADE = entity.Nacionalidade,
                NATURALIDADE = entity.Naturalidade,
                DTNASCIMENTO = entity.Dtnascimento,
                SEXO = entity.Sexo,
                NOMEPAI = entity.Nomepai,
                NOMEMAE = entity.Nomemae,
                CEP = entity.Cep,
                ENDERECO = entity.Endereco,
                BAIRRO = entity.Bairro,
                NUMERO = entity.Numero,
                COMPLEMENTO = entity.Complemento,
                CIDADE = entity.Cidade,
                ESTADO = entity.Estado,
                TEL_RESIDENCIAL = entity.Telresidencial,
                TEL_COMERCIAL = entity.Telcomercial,
                TEL_CELULAR = entity.Telcelular,
                SENHA = entity.Senha,
                CAD_ADMINISTRACAO = entity.Cadadministracao,
                ENVIO_SENHA = entity.Enviosenha,
                INSTITUICAO = entity.Instituicao,
                DTCONCLUSAO = entity.Dtconclusao,
                DTCADASTRO = DateTime.Now,
                DTALTERACAO = DateTime.Now,
                //DTULTIMOACESSO = entity.Dtultimoacesso,
                RECEBERFEEDS = entity.Receberfeeds,
                ORGAOTRABALHOID = entity.Orgaotrabalhoid,
                ESCOLARIDADEID = entity.Escolaridadeid
            };

            //using (var transaction = new System.Transactions.TransactionScope())
            //{
            var user = new ApplicationUser { UserName = entity.Cpf, Email = entity.Email };
            var result = UserManager.CreateAsync(user, entity.Senha).Result;
            if (!result.Succeeded)
            {
                var erros = string.Empty;
                foreach (var item in result.Errors) erros += item.ToString() + " ";
                if (erros.Contains("is already taken") && erros.Contains("Email"))
                    erros = erros.Replace("is already taken", "já existe");
                if (erros == "Passwords must have at least one non letter or digit character. Passwords must have at least one uppercase ('A'-'Z').")
                    erros = "As senhas devem ter pelo menos um caractere não letra ou dígito. As senhas devem ter pelo menos uma maiúscula('A' - 'Z').";

                throw new Exception(string.Format("Ocorreu um erro ao cadastrar o cliente: {0}", erros));
            }

            var userIdentity = UserManager.FindByNameAsync(entity.Cpf).Result;

            cliente.USERID = userIdentity.Id;
            if (entity.Idantigo != 0) cliente.IDANTIGO = entity.Idantigo;
            if (entity.Qtdacesso != 0) cliente.QTDACESSO = entity.Qtdacesso;

            m_ClienteService.Add(cliente);
            var comit = m_ClienteService.Commit();
            //transaction.Complete();
            return comit;
            //}
        }

        /// <summary>
        /// Metodo delete realizando a exclusão logica. E necessario validar se existe contraint neste registro antes de realizar a exclusão do registro.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(ClienteViewModel entity)
        {
            var cliente = m_ClienteService.GetById(entity.Id);
            if (cliente != null)
            {
                cliente.DTEXCLUSAO = DateTime.Now;
                m_ClienteService.Update(cliente);
            }

            return m_ClienteService.Commit();
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return m_ClienteService.GetAll().Select(item => ConvertToClienteViewModel(item));
        }

        public ClienteViewModel GetByCpf(string cpf)
        {
            var item = m_ClienteService.FindBy(x => x.CPF.Equals(cpf)).FirstOrDefault();
            if (item != null) return ConvertToClienteViewModel(item);
            return null;
        }

        public ClienteViewModel GetById(int id)
        {
            var item = m_ClienteService.GetById(id);
            if (item != null) return ConvertToClienteViewModel(item);
            return null;
        }

        public ClienteViewModel1 GetByRefreshToken(string refresh_token)
        {
            var refreshToken = m_RefreshtokenServices.FindBy(x => x.HASH == refresh_token);
            if (refresh_token == null) return null;

            var userid = refreshToken.FirstOrDefault().USERID;
            return m_ClienteService.FindBy(x => x.USERID == userid).Select(item => new ClienteViewModel1
            {
                Id = item.ID,
                Nome = item.NOME,
                Qtdacesso = item.QTDACESSO ?? 0,
                Receberfeeds = item.RECEBERFEEDS ?? 0
            }).FirstOrDefault();
        }

        public PaginacaoClientes GetClientePaginacao(string order, int offset, int limit)
        {
            var total = m_ClienteService.GetTotalRegistros();
            var dataClientes = m_ClienteService.GetClientePaginacao(order, offset, limit).Select(item => ConvertToClienteViewModel(item));

            return new PaginacaoClientes { total = total, rows = dataClientes };
        }

        public PaginacaoClientes GetClientePaginacao(FilterClientes filter, string order, int offset, int limit)
        {
            var total = m_ClienteService.GetTotalRegistros(filter);
            var dataClientes = m_ClienteService.GetClientePaginacao(filter, order, offset, limit).Select(item => ConvertToClienteViewModel(item));

            return new PaginacaoClientes { total = total, rows = dataClientes };
        }

        public IEnumerable<ClienteViewModel> GetTopClientes()
        {
            var clientes = m_ClienteService.GetClientePaginacao("asc", 0, 10).Select(item => ConvertToClienteViewModel(item));
            return clientes;
        }

        public int Update(ClienteViewModel entity)
        {
            if (string.IsNullOrEmpty(entity.Orgaoemissor)) throw new Exception("Favor informar orgão emissor.");
            if (string.IsNullOrEmpty(entity.Ufemissor)) throw new Exception("Favor informar uf emissor.");
            if (entity.Orgaotrabalhoid <= 0) throw new Exception("Favor informar orgão de trabalho.");
            if (entity.Escolaridadeid <= 0) throw new Exception("Favor informar escolaridade.");
            if (entity.Dtnascimento == null) throw new Exception("Favor informar data de nascimento.");

            var item = m_ClienteService.GetById(entity.Id);
            if (item != null)
            {
                item.NOME = entity.Nome;
                item.EMAIL = entity.Email;
                item.RG = entity.Rg;
                item.ORGAOEMISSOR = entity.Orgaoemissor;
                item.UFEMISSOR = entity.Ufemissor;
                item.DTEMISSAO = entity.Dtemissao;
                item.ORGAOEMISSOR = entity.Orgaoemissor;
                item.NACIONALIDADE = entity.Nacionalidade;
                item.NATURALIDADE = entity.Naturalidade;
                item.DTNASCIMENTO = entity.Dtnascimento;
                item.SEXO = entity.Sexo;
                item.NOMEPAI = entity.Nomepai;
                item.NOMEMAE = entity.Nomemae;
                item.CEP = entity.Cep;
                item.ENDERECO = entity.Endereco;
                item.BAIRRO = entity.Bairro;
                item.NUMERO = entity.Numero;
                item.COMPLEMENTO = entity.Complemento;
                item.CIDADE = entity.Cidade;
                item.ESTADO = entity.Estado;
                item.TEL_RESIDENCIAL = entity.Telresidencial;
                item.TEL_COMERCIAL = entity.Telcomercial;
                item.TEL_CELULAR = entity.Telcelular;
                item.SENHA = entity.Senha;
                item.CAD_ADMINISTRACAO = entity.Cadadministracao;
                item.ENVIO_SENHA = entity.Enviosenha;
                item.ORGAOTRABALHOID = entity.Orgaotrabalhoid;
                item.ESCOLARIDADEID = entity.Escolaridadeid;
                item.INSTITUICAO = entity.Instituicao;
                item.DTCONCLUSAO = entity.Dtconclusao;
                item.DTALTERACAO = DateTime.Now;
                item.RECEBERFEEDS = entity.Receberfeeds;
            }
            return m_ClienteService.Commit();
        }

        private ClienteViewModel ConvertToClienteViewModel(EV_CLIENTE item)
        {
            var clienteViewModel = new ClienteViewModel
            {
                Id = item.ID,
                Nome = item.NOME,
                Email = item.EMAIL,
                Rg = item.RG,
                Orgaoemissor = item.ORGAOEMISSOR,
                Ufemissor = item.UFEMISSOR,
                Dtemissao = item.DTEMISSAO,
                Cpf = item.CPF,
                Nacionalidade = item.NACIONALIDADE,
                Naturalidade = item.NATURALIDADE,
                Dtnascimento = item.DTNASCIMENTO ?? DateTime.Now,
                Sexo = item.SEXO,
                Nomepai = item.NOMEPAI,
                Nomemae = item.NOMEMAE,
                Cep = item.CEP,
                Endereco = item.ENDERECO,
                Bairro = item.BAIRRO,
                Numero = item.NUMERO ?? 0,
                Complemento = item.COMPLEMENTO,
                Cidade = item.CIDADE,
                Estado = item.ESTADO,
                Telresidencial = item.TEL_RESIDENCIAL,
                Telcomercial = item.TEL_COMERCIAL,
                Telcelular = item.TEL_CELULAR,
                Senha = item.SENHA,
                Cadadministracao = item.CAD_ADMINISTRACAO,
                Enviosenha = item.ENVIO_SENHA,
                Orgaotrabalhoid = item.ORGAOTRABALHOID ?? 0,
                Escolaridadeid = item.ESCOLARIDADEID ?? 0,
                Instituicao = item.INSTITUICAO,
                Dtconclusao = item.DTCONCLUSAO ?? DateTime.Now,
                Dtalteracao = item.DTALTERACAO ?? DateTime.Now,
                Dtultimoacesso = item.DTULTIMOACESSO ?? DateTime.Now,
                Idantigo = item.IDANTIGO ?? 0,
                Idorgaoantigo = item.IDORGAOANTIGO ?? 0,
                Idescolaridadeantigo = item.IDESCOLARIDADEANTIGO ?? 0,
                Qtdacesso = item.QTDACESSO ?? 0,
                Receberfeeds = item.RECEBERFEEDS ?? 0,
            };
            if (item.AD_ORGAOS != null)
            {
                clienteViewModel.OrgaoTrabalho = item.AD_ORGAOS.ORGAO;
            }
            else
            {
                clienteViewModel.OrgaoTrabalho = "Sem Informação";
            }

            if (item.EV_INSCRICAO != null)
            {
                if (item.EV_INSCRICAO.Count > 0)
                {
                    clienteViewModel.Inscricoes = item.EV_INSCRICAO.Select(insc => new InscricaoViewModel
                    {
                        Baixa = insc.BAIXA,
                        Boletoemitido = insc.BOLETOEMITIDO,
                        Clienteid = insc.CLIENTEID,
                        Criado = insc.CRIADO ?? DateTime.Now,
                        Datapagamento = insc.DATAPAGAMENTO ?? DateTime.Now,
                        Dtboletoemitido = insc.DTBOLETOEMITIDO ?? DateTime.Now,
                        Dtinscricao = insc.DTINSCRICAO,
                        Formapagamento = insc.FORMAPAGAMENTO,
                        Id = item.ID,
                        Pago = insc.PAGO,
                        Turno = insc.TURNO,
                        Valor = insc.VALOR,
                        Valorrecebido = insc.VALORRECEBIDO ?? 0,
                        NomeCliente = item.NOME,
                        Evento = m_EventoService.GetById(insc.EVENTOID).NOME,
                        Dtalteracao = insc.DTALTERACAO,
                        Dtcadastro = insc.DTCADASTRO,
                        Dtexclusao = insc.DTEXCLUSAO,
                        Dtpagamento = insc.DATAPAGAMENTO.HasValue ? insc.DATAPAGAMENTO.Value.ToString("dd/MM/yyyy") : "Sem informação"
                    });
                }
                else
                {
                    clienteViewModel.Inscricoes = new List<InscricaoViewModel>();
                }
            }
            return clienteViewModel;
        }

        public PaginacaoClientes GetClientePaginacao(FilterClientes filter)
        {
            var total = m_ClienteService.GetTotalRegistros(filter);
            var dataClientes = m_ClienteService.GetClientePaginacao(filter, "asc", 0, 10).Select(item => ConvertToClienteViewModel(item));

            return new PaginacaoClientes { total = total, rows = dataClientes };
        }

        public IEnumerable<dynamic> GetClientes(int avaliacaoid)
        {
            return m_ClienteService.GetClientes(avaliacaoid);
        }
    }
}