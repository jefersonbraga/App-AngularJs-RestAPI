using System;
using System.Collections.Generic;
using System.Linq;
using Cursos.Business.Interfaces;
using Cursos.Repository.Services.Interfaces;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class EventoBusiness : IEventoBusiness
    {
        private readonly IEventoturnosService m_EventoturnosService;
        private readonly IEventodatasService m_EventodatasService;

        public EventoBusiness(IEventoService pEventoService, IEventoturnosService pEventoturnosService, IEventodatasService pEventodatasService)
        {
            m_EventoService = pEventoService;
            m_EventoturnosService = pEventoturnosService;
            m_EventodatasService = pEventodatasService;
        }

        public int Add(EventoViewModel entity)
        {
            if (entity.Dtinicio == DateTime.MinValue)
                entity.Dtinicio = DateTime.Now;

            if (entity.Dttermino == DateTime.MinValue)
                entity.Dttermino = DateTime.Now;

            using (var transaction = new System.Transactions.TransactionScope())
            {
                var evento = new Data.EV_EVENTO
                {
                    DESCRICAO = entity.Descricao,
                    DISPONIVEL = entity.Disponivel,
                    DTINICIO = entity.Dtinicio,
                    DTTERMINO = entity.Dttermino,
                    ENDERECO = entity.Endereco,
                    EXIBIRLOCAL = entity.Exibirlocal,
                    FREQUENCIA = entity.Frequencia,
                    HORATERMINO = entity.Horatermino,
                    HORAINICIO = entity.Horainicio,
                    INSCRICAO = entity.Inscricao,
                    LOCALID = entity.Localid,
                    MENSAGEMCOMPROVANTE = entity.Mensagemcomprovante,
                    MENSAGEMBOLETO = entity.Mensagemboleto,
                    NOME = entity.Nome,
                    QTDVAGAS = entity.Qtdvagas,
                    SITUACAO = entity.Situacao,
                    VALOREVENTO = entity.Valorevento,
                    VECIMENTOBOLETO = entity.Vecimentoboleto,
                    TP_EVENTO = entity.Tpevento,
                    DTCADASTRO = DateTime.Now,
                    DTATUALIZACAO = DateTime.Now,
                };
                m_EventoService.Add(evento);

                var retorno = m_EventoService.Commit();

                if (entity.Turnos != null)
                {
                    var turnos = m_EventoturnosService.FindBy(x => x.IDEVENTO == evento.ID);
                    if (turnos != null)
                    {
                        foreach (var item in turnos)
                            m_EventoturnosService.Delete(item);
                    }

                    foreach (var item in entity.Turnos)
                    {
                        m_EventoturnosService.Add(new Data.EV_EVENTOTURNOS
                        {
                            IDEVENTO = evento.ID,
                            IDTURNO = item.Idturno,
                            DTATUALIZACAO = DateTime.Now,
                            DTCADASTRO = DateTime.Now
                        });
                    }

                    retorno += m_EventoturnosService.Commit();
                }
                if (entity.Eventodatas != null)
                {
                    var itemsData = m_EventodatasService.GetEventoDataByEvento(entity.Id);
                    foreach (var item in itemsData)
                        m_EventodatasService.Delete(item);

                    foreach (var item in entity.Eventodatas)
                    {
                        m_EventodatasService.Add(new Data.EV_EVENTODATAS
                        {
                            DTINICIO = item.Dtinicio,
                            DTTERMINO = item.Dttermino,
                            HORAINICIO = item.Horainicio,
                            HORATERMINO = item.Horatermino,
                            IDEVENTO = entity.Id
                        });
                    }

                    m_EventodatasService.Commit();
                }
                transaction.Complete();
                return retorno;
            }
        }

        public int Delete(EventoViewModel entity)
        {
            var item = m_EventoService.GetById(entity.Id);
            if (item != null)

            {
                item.DTEXCLUSAO = DateTime.Now;
                m_EventoService.Update(item);
            }
            return m_EventoService.Commit();
        }

        public IEnumerable<EventoViewModel> GetAllCombo()
        {
            var eventos = m_EventoService.GetAllEventoInscritos().Select(item => new EventoViewModel
            {
                Descricao = item.DESCRICAO,
                Disponivel = item.DISPONIVEL,
                Dtinicio = item.DTINICIO ?? DateTime.Now,
                Dttermino = item.DTTERMINO ?? DateTime.Now,
                Endereco = item.ENDERECO,
                Exibirlocal = item.EXIBIRLOCAL,
                Frequencia = item.FREQUENCIA ?? 0,
                Horainicio = item.HORAINICIO,
                Horatermino = item.HORATERMINO,
                Id = item.ID,
                Inscricao = item.INSCRICAO,
                Localid = item.LOCALID.Value,
                Mensagemboleto = item.MENSAGEMBOLETO,
                Mensagemcomprovante = item.MENSAGEMCOMPROVANTE,
                Nome = item.NOME,
                Qtdvagas = item.QTDVAGAS ?? 0,
                Situacao = item.SITUACAO,
                Temaid = item.TEMAID ?? 0,
                Tpevento = item.TP_EVENTO,
                Valorevento = item.VALOREVENTO,
                Vecimentoboleto = item.VECIMENTOBOLETO ?? DateTime.Now,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                DataInicio = item.DTINICIO.HasValue ? item.DTINICIO.Value.ToShortDateString() : string.Empty,
                DataTermino = item.DTTERMINO.HasValue ? item.DTTERMINO.Value.ToShortDateString() : string.Empty,
            });
            return eventos.OrderBy(x => x.Descricao);
        }

        public IEnumerable<EventoViewModel> GetAll()
        {
            var eventos = m_EventoService.GetAll().Select(item => new EventoViewModel
            {
                Descricao = item.DESCRICAO,
                Disponivel = item.DISPONIVEL,
                Dtinicio = item.DTINICIO ?? DateTime.Now,
                Dttermino = item.DTTERMINO ?? DateTime.Now,
                Endereco = item.ENDERECO,
                Exibirlocal = item.EXIBIRLOCAL,
                Frequencia = item.FREQUENCIA ?? 0,
                Horainicio = item.HORAINICIO,
                Horatermino = item.HORATERMINO,
                Id = item.ID,
                Inscricao = item.INSCRICAO,
                Localid = item.LOCALID.Value,
                Mensagemboleto = item.MENSAGEMBOLETO,
                Mensagemcomprovante = item.MENSAGEMCOMPROVANTE,
                Nome = item.NOME,
                Qtdvagas = item.QTDVAGAS ?? 0,
                Situacao = item.SITUACAO,
                Temaid = item.TEMAID ?? 0,
                Tpevento = item.TP_EVENTO,
                Valorevento = item.VALOREVENTO,
                Vecimentoboleto = item.VECIMENTOBOLETO ?? DateTime.Now,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                DataInicio = item.DTINICIO.HasValue ? item.DTINICIO.Value.ToShortDateString() : string.Empty,
                DataTermino = item.DTTERMINO.HasValue ? item.DTTERMINO.Value.ToShortDateString() : string.Empty,
                Eventodatas = item.EV_EVENTODATAS == null ? new List<EventodatasViewModel>() : item.EV_EVENTODATAS.Select(datas => new EventodatasViewModel
                {
                    Dtinicio = datas.DTINICIO,
                    Dttermino = datas.DTTERMINO,
                    Horainicio = datas.HORAINICIO,
                    Horatermino = datas.HORATERMINO,
                    Idevento = datas.IDEVENTO,
                    Id = datas.ID
                }),
                Turnos = m_EventoturnosService.FindBy(x => x.IDEVENTO == item.ID).Select(turno => new EventoturnosViewModel
                {
                    Descricao = turno.IDTURNO == 1 ? "Manha" : turno.IDTURNO == 2 ? "Tarde" : "Noite",
                    Dtatualizacao = turno.DTATUALIZACAO,
                    Dtcadastro = turno.DTCADASTRO,
                    Idevento = turno.IDEVENTO,
                    Idturno = turno.IDTURNO
                })
            });
            return eventos;
        }

        public EventoViewModel GetById(int id)
        {
            var item = m_EventoService.GetById(id);
            if (item != null)
            {
                return new EventoViewModel
                {
                    Descricao = item.DESCRICAO,
                    Disponivel = item.DISPONIVEL,
                    Dtinicio = item.DTINICIO ?? DateTime.Now,
                    Dttermino = item.DTTERMINO ?? DateTime.Now,
                    Endereco = item.ENDERECO,
                    Exibirlocal = item.EXIBIRLOCAL,
                    Frequencia = item.FREQUENCIA ?? 0,
                    Horainicio = item.HORAINICIO,
                    Horatermino = item.HORATERMINO,
                    Id = item.ID,
                    Inscricao = item.INSCRICAO,
                    Localid = item.LOCALID.Value,
                    Mensagemcomprovante = item.MENSAGEMCOMPROVANTE,
                    Mensagemboleto = item.MENSAGEMBOLETO,
                    Nome = item.NOME,
                    Qtdvagas = item.QTDVAGAS ?? 0,
                    Situacao = item.SITUACAO,
                    Temaid = item.TEMAID ?? 0,
                    Tpevento = item.TP_EVENTO,
                    Valorevento = item.VALOREVENTO,
                    Vecimentoboleto = item.VECIMENTOBOLETO ?? DateTime.Now,
                    Dtatualizacao = item.DTATUALIZACAO,
                    Dtcadastro = item.DTCADASTRO,
                    Dtexclusao = item.DTEXCLUSAO,
                    DataInicio = item.DTINICIO.HasValue ? item.DTINICIO.Value.ToString("dd/MM/yyyy") : string.Empty,
                    DataTermino = item.DTTERMINO.HasValue ? item.DTTERMINO.Value.ToString("dd/MM/yyyy") : string.Empty,
                    Eventodatas = item.EV_EVENTODATAS == null ? new List<EventodatasViewModel>() : item.EV_EVENTODATAS.Select(datas => new EventodatasViewModel
                    {
                        Dtinicio = datas.DTINICIO,
                        Dttermino = datas.DTTERMINO,
                        Horainicio = datas.HORAINICIO,
                        Horatermino = datas.HORATERMINO,
                        Idevento = datas.IDEVENTO,
                        Id = datas.ID
                    }),
                };
            }
            return new EventoViewModel();
        }

        public EventoPaginacao GetEventoPaginacao(string order, int offset, int limit)
        {
            var totalRegistros = m_EventoService.GetTotalRegistros();
            var consulta = m_EventoService.GetEventoPaginacao(order, offset, limit).Select(item => new EventoViewModel
            {
                Descricao = item.DESCRICAO,
                Disponivel = item.DISPONIVEL,
                Dtinicio = item.DTINICIO ?? DateTime.Now,
                Dttermino = item.DTTERMINO ?? DateTime.Now,
                Endereco = item.ENDERECO,
                Exibirlocal = item.EXIBIRLOCAL,
                Frequencia = item.FREQUENCIA ?? 0,
                Horainicio = item.HORAINICIO,
                Horatermino = item.HORATERMINO,
                Id = item.ID,
                Inscricao = item.INSCRICAO,
                Localid = item.LOCALID.Value,
                Mensagemboleto = item.MENSAGEMBOLETO,
                Mensagemcomprovante = item.MENSAGEMCOMPROVANTE,
                Nome = item.NOME,
                Qtdvagas = item.QTDVAGAS ?? 0,
                Situacao = item.SITUACAO,
                Temaid = item.TEMAID ?? 0,
                Tpevento = item.TP_EVENTO,
                Valorevento = item.VALOREVENTO,
                Vecimentoboleto = item.VECIMENTOBOLETO ?? DateTime.Now,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                DataInicio = item.DTINICIO.HasValue ? item.DTINICIO.Value.ToString("dd/MM/yyyy") : string.Empty,
                DataTermino = item.DTTERMINO.HasValue ? item.DTTERMINO.Value.ToString("dd/MM/yyyy") : string.Empty,
                Eventodatas = item.EV_EVENTODATAS == null ? new List<EventodatasViewModel>() : item.EV_EVENTODATAS.Select(datas => new EventodatasViewModel
                {
                    Dtinicio = datas.DTINICIO,
                    Dttermino = datas.DTTERMINO,
                    Horainicio = datas.HORAINICIO,
                    Horatermino = datas.HORATERMINO,
                    Idevento = datas.IDEVENTO,
                    Id = datas.ID
                }),
                Turnos = m_EventoturnosService.FindBy(x => x.IDEVENTO == item.ID).Select(turno => new EventoturnosViewModel
                {
                    Descricao = turno.IDTURNO == 1 ? "Manha" : turno.IDTURNO == 2 ? "Tarde" : "Noite",
                    Dtatualizacao = turno.DTATUALIZACAO,
                    Dtcadastro = turno.DTCADASTRO,
                    Idevento = turno.IDEVENTO,
                    Idturno = turno.IDTURNO
                })
            });
            return new EventoPaginacao() { total = totalRegistros, rows = consulta.ToList() };
        }

        public EventoPaginacao GetEventoPaginacao(string search, string order, int offset, int limit)
        {
            var totalRegistros = m_EventoService.GetTotalRegistros(search);
            var consulta = m_EventoService.GetEventoPaginacao(search, order, offset, limit).Select(item => new EventoViewModel
            {
                Descricao = item.DESCRICAO,
                Disponivel = item.DISPONIVEL,
                Dtinicio = item.DTINICIO ?? DateTime.Now,
                Dttermino = item.DTTERMINO ?? DateTime.Now,
                Endereco = item.ENDERECO,
                Exibirlocal = item.EXIBIRLOCAL,
                Frequencia = item.FREQUENCIA ?? 0,
                Horainicio = item.HORAINICIO,
                Horatermino = item.HORATERMINO,
                Id = item.ID,
                Inscricao = item.INSCRICAO,
                Localid = item.LOCALID.Value,
                Mensagemboleto = item.MENSAGEMBOLETO,
                Mensagemcomprovante = item.MENSAGEMCOMPROVANTE,
                Nome = item.NOME,
                Qtdvagas = item.QTDVAGAS ?? 0,
                Situacao = item.SITUACAO,
                Temaid = item.TEMAID ?? 0,
                Tpevento = item.TP_EVENTO,
                Valorevento = item.VALOREVENTO,
                Vecimentoboleto = item.VECIMENTOBOLETO ?? DateTime.Now,
                Dtatualizacao = item.DTATUALIZACAO,
                Dtcadastro = item.DTCADASTRO,
                Dtexclusao = item.DTEXCLUSAO,
                DataInicio = item.DTINICIO.HasValue ? item.DTINICIO.Value.ToString("dd/MM/yyyy") : string.Empty,
                DataTermino = item.DTTERMINO.HasValue ? item.DTTERMINO.Value.ToString("dd/MM/yyyy") : string.Empty,
                Eventodatas = item.EV_EVENTODATAS == null ? new List<EventodatasViewModel>() : item.EV_EVENTODATAS.Select(datas => new EventodatasViewModel
                {
                    Dtinicio = datas.DTINICIO,
                    Dttermino = datas.DTTERMINO,
                    Horainicio = datas.HORAINICIO,
                    Horatermino = datas.HORATERMINO,
                    Idevento = datas.IDEVENTO,
                    Id = datas.ID
                }),
                Turnos = m_EventoturnosService.FindBy(x => x.IDEVENTO == item.ID).Select(turno => new EventoturnosViewModel
                {
                    Descricao = turno.IDTURNO == 1 ? "Manha" : turno.IDTURNO == 2 ? "Tarde" : "Noite",
                    Dtatualizacao = turno.DTATUALIZACAO,
                    Dtcadastro = turno.DTCADASTRO,
                    Idevento = turno.IDEVENTO,
                    Idturno = turno.IDTURNO
                })
            });
            return new EventoPaginacao() { total = totalRegistros, rows = consulta.ToList() };
        }

        public int Update(EventoViewModel entity)
        {
            var item = m_EventoService.GetById(entity.Id);
            if (item != null)
            {
                using (var transaction = new System.Transactions.TransactionScope())
                {
                    item.TEMAID = entity.Temaid;
                    if (entity.Temaid == 0)
                        item.TEMAID = null;

                    item.DESCRICAO = entity.Descricao.Trim();
                    item.DISPONIVEL = entity.Disponivel;

                    item.DTINICIO = entity.Dtinicio;
                    if (entity.Dtinicio == DateTime.MinValue)
                        item.DTINICIO = DateTime.Now;

                    if (item.DTTERMINO == DateTime.MinValue)
                        item.DTTERMINO = DateTime.Now;

                    item.HORAINICIO = entity.Horainicio;
                    item.HORATERMINO = entity.Horatermino;

                    item.ENDERECO = entity.Endereco;
                    item.EXIBIRLOCAL = entity.Exibirlocal;
                    item.FREQUENCIA = entity.Frequencia;

                    item.INSCRICAO = entity.Inscricao;
                    item.LOCALID = entity.Localid;
                    item.MENSAGEMBOLETO = entity.Mensagemboleto.Trim();
                    item.MENSAGEMCOMPROVANTE = entity.Mensagemcomprovante.Trim();
                    item.NOME = entity.Nome;
                    item.QTDVAGAS = entity.Qtdvagas;
                    item.SITUACAO = entity.Situacao;
                    item.TP_EVENTO = entity.Tpevento;
                    item.VALOREVENTO = entity.Valorevento;
                    item.VECIMENTOBOLETO = entity.Vecimentoboleto;
                    item.DTATUALIZACAO = DateTime.Now;
                    m_EventoService.Update(item);

                    var retorno = m_EventoService.Commit();

                    if (entity.Turnos != null)
                    {
                        var turnos = m_EventoturnosService.FindBy(x => x.IDEVENTO == entity.Id);
                        if (turnos.Any())
                        {
                            foreach (var deleteItem in turnos)
                            {
                                m_EventoturnosService.Delete(deleteItem);
                            }
                        }

                        foreach (var itemTurnos in entity.Turnos)
                        {
                            m_EventoturnosService.Add(new Data.EV_EVENTOTURNOS
                            {
                                IDEVENTO = entity.Id,
                                IDTURNO = itemTurnos.Idturno,
                                DTATUALIZACAO = DateTime.Now,
                                DTCADASTRO = DateTime.Now
                            });
                        }

                        var itemsData = m_EventodatasService.GetEventoDataByEvento(entity.Id);
                        foreach (var itemDelete in itemsData)
                            m_EventodatasService.Delete(itemDelete);

                        foreach (var itemInsert in entity.Eventodatas)
                        {
                            m_EventodatasService.Add(new Data.EV_EVENTODATAS
                            {
                                DTINICIO = itemInsert.Dtinicio,
                                DTTERMINO = itemInsert.Dttermino,
                                HORAINICIO = itemInsert.Horainicio,
                                HORATERMINO = itemInsert.Horatermino,
                                IDEVENTO = item.ID
                            });
                            retorno += m_EventodatasService.Commit();
                        }

                        retorno += m_EventoturnosService.Commit();
                    }
                    transaction.Complete();
                    return retorno;
                }
            }
            return 0;
        }
    }
}