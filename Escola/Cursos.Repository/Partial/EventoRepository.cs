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
    public partial class EventoRepository
    {
        public IEnumerable<EV_EVENTO> GetAllEventoInscritos()
        {
            var query = Dbset.Include("EV_INSCRICAO").OrderBy(x => x.DTCADASTRO);
            var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_EVENTO>>(ctx => query.Where(X => X.EV_INSCRICAO.Count() > 0));
            return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
        }

        public IEnumerable<EV_EVENTO> GetEventoPaginacao(string order, int offset, int limit)
        {
            var skip = (offset - 1) * limit < 0 ? 0 : (offset - 1) * limit;
            if (order == "asc")
            {
                var query = Dbset.Include("EV_EVENTODATAS").OrderBy(x => x.DTCADASTRO);
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_EVENTO>>(ctx => query.Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
            else
            {
                var query = Dbset.Include("EV_EVENTODATAS").OrderByDescending(x => x.DTCADASTRO);
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_EVENTO>>(ctx => query.Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
        }

        public IEnumerable<EV_EVENTO> GetEventoPaginacao(string search, string order, int offset, int limit)
        {
            var skip = (offset - 1) * limit < 0 ? 0 : (offset - 1) * limit;

            var query = Dbset.Include("EV_EVENTODATAS").Where(x => x.NOME.Contains(search)
                           || x.NOME.Contains(search)
                           || x.SITUACAO.Contains(search)
                           || x.DISPONIVEL.Contains(search));

            if (order == "asc")
            {
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_EVENTO>>(ctx => query.OrderBy(x => x.DTCADASTRO).Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
            else
            {
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_EVENTO>>(ctx => query.OrderByDescending(x => x.DTCADASTRO).Skip(skip).Take(limit));
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
            try
            {
                var query = Dbset.Where(x => x.NOME.Contains(search)
                          || x.SITUACAO.Contains(search)
                          || x.DISPONIVEL.Contains(search)).Count();

                var _object = CompiledQuery.Compile<ObjectContext, int>(ctx => query);
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}