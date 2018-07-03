using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;

namespace Cursos.Repository
{
    public partial class InscricaoRepository
    {
        public virtual IEnumerable<EV_INSCRICAO> GetInscricaoByClienteId(int clientId)
        {
            var query = Dbset.Include("EV_EVENTO").Include("EV_CLIENTE").Where(x => x.CLIENTEID == clientId).OrderBy(x => x.CRIADO);
            var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_INSCRICAO>>(ctx => query);
            return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
        }

        public IEnumerable<EV_INSCRICAO> GetInscricaoPaginacao(string order, int offset, int limit)
        {
            var skip = (offset - 1) * limit < 0 ? 0 : (offset - 1) * limit;
            if (order == "asc")
            {
                var query = Dbset.Include("EV_EVENTO").Include("EV_CLIENTE").OrderBy(x => x.CRIADO);
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_INSCRICAO>>(ctx => query.Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
            else
            {
                var query = Dbset.Include("EV_EVENTO").Include("EV_CLIENTE").OrderByDescending(x => x.CRIADO);
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_INSCRICAO>>(ctx => query.Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
        }

        public IEnumerable<EV_INSCRICAO> GetInscricaoPaginacao(string search, string order, int offset, int limit)
        {
            var skip = (offset - 1) * limit < 0 ? 0 : (offset - 1) * limit;

            var date = DateTime.TryParse(search, out DateTime dataPagamento);
            if (date)
            {
                var query = Dbset.Include("EV_EVENTO").Include("EV_CLIENTE").Where(x => x.DATAPAGAMENTO.Equals(dataPagamento));
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_INSCRICAO>>(ctx => query.Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }

            if (order == "asc")
            {
                var query = Dbset.Include("EV_EVENTO").Include("EV_CLIENTE").Where(x => x.EV_EVENTO.NOME.Contains(search) ||
                x.EV_CLIENTE.NOME.Contains(search) || x.PAGO.Contains(search) || x.BOLETOEMITIDO.Contains(search) || x.TURNO.Contains(search));

                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_INSCRICAO>>(ctx => query.Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
            else
            {
                var query = Dbset.Include("EV_EVENTO").Include("EV_CLIENTE").Where(x => x.EV_EVENTO.NOME.Contains(search) ||
                x.EV_CLIENTE.NOME.Contains(search) || x.PAGO.Contains(search) || x.BOLETOEMITIDO.Contains(search) || x.TURNO.Contains(search));

                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_INSCRICAO>>(ctx => query.Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
        }

        public int GetTotalRegistros()
        {
            var _object = CompiledQuery.Compile<ObjectContext, int>(ctx => Dbset.Count());
            return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext);
        }

        public int GetTotalRegistros(string search)
        {
            int totalRegistros = 0;
            var date = DateTime.TryParse(search, out DateTime dataPagamento);
            if (date)
            {
                totalRegistros = Dbset.Include("EV_EVENTO").Include("EV_CLIENTE").Where(x => x.DATAPAGAMENTO.Equals(dataPagamento)).Count();
            }
            else
            {
                totalRegistros = Dbset.Include("EV_EVENTO").Include("EV_CLIENTE").Where(x => x.EV_EVENTO.NOME.Contains(search) ||
                x.EV_CLIENTE.NOME.Contains(search) || x.PAGO.Contains(search) || x.BOLETOEMITIDO.Contains(search) || x.TURNO.Contains(search)).Count();
            }

            var _object = CompiledQuery.Compile<ObjectContext, int>(ctx => totalRegistros);
            return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext);
        }
    }
}