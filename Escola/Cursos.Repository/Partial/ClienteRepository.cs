using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Data;
using Cursos.ViewModel;

namespace Cursos.Repository
{
    public partial class ClienteRepository
    {
        public IEnumerable<dynamic> GetClientes(int avaliacaoid)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_context.Database.Connection.ConnectionString))
            {
                var queryString = "SELECT distinct c.ID, c.NOME FROM [DMP_Wescola].[dbo].[EV_AVALIACAO] a inner join EV_EVENTO b on a.EVENTOID = b.ID ";
                queryString += string.Format("inner join EV_INSCRICAO e on e.EVENTOID = b.ID inner join EV_CLIENTE c on e.CLIENTEID = c.ID Where a.ID = {0}", avaliacaoid);

                var command = new SqlCommand(queryString, connection);
                if (connection.State == System.Data.ConnectionState.Closed) connection.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    var tb = new DataTable();
                    tb.Load(dr);
                    if (connection.State == System.Data.ConnectionState.Open) connection.Close();

                    return tb.AsEnumerable().Select(x => new { Id = (int)x["ID"], Nome = x["NOME"].ToString() });
                }
            }
        }

        public IEnumerable<EV_CLIENTE> GetClientePaginacao(string order, int offset, int limit)
        {
            var skip = (offset - 1) * limit < 0 ? 0 : (offset - 1) * limit;
            if (order == "asc")
            {
                var query = Dbset.Include("AD_ORGAOS").Include("EV_INSCRICAO").OrderBy(x => x.DTCADASTRO);
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_CLIENTE>>(ctx => query.Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
            else
            {
                var query = Dbset.Include("AD_ORGAOS").Include("EV_INSCRICAO").OrderByDescending(x => x.DTCADASTRO);
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_CLIENTE>>(ctx => query.Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
        }

        public IEnumerable<EV_CLIENTE> GetClientePaginacao(FilterClientes filter, string order, int offset, int limit)
        {
            var skip = (offset - 1) * limit < 0 ? 0 : (offset - 1) * limit;

            var query = Dbset.Include("AD_ORGAOS").Include("EV_INSCRICAO").Where(x =>
               (x.NOME.Contains(filter.Nome) || filter.Nome == null)
            && (x.NOME.StartsWith(filter.Letra) || filter.Letra == null)
            && (x.RG.StartsWith(filter.Rg) || filter.Rg == null)
            && (x.INSTITUICAO.Contains(filter.Instituicao) || filter.Instituicao == null)
            && (x.SEXO.Contains(filter.Sexo) || filter.Sexo == null)
            && (x.TEL_CELULAR.Contains(filter.Telcelular) || filter.Telcelular == null)
            && (x.CPF.StartsWith(filter.Cpf) || filter.Cpf == null)
            && (x.EMAIL.Contains(filter.Email) || filter.Email == null)
            && (x.CIDADE.Contains(filter.Cidade) || filter.Cidade == null)
            && (x.DTNASCIMENTO == filter.Dtaniversario || filter.Dtaniversario == null)
            && (x.EV_INSCRICAO.Any(y => y.EVENTOID == filter.Eventoid) || filter.Eventoid == null || filter.Eventoid == 0));

            if (order == "asc")
            {
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_CLIENTE>>(ctx => query.OrderBy(x => x.DTCADASTRO).Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
            else
            {
                var _object = CompiledQuery.Compile<ObjectContext, IQueryable<EV_CLIENTE>>(ctx => query.OrderByDescending(x => x.DTCADASTRO).Skip(skip).Take(limit));
                return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext).ToList();
            }
        }

        public int GetTotalRegistros()
        {
            var _object = CompiledQuery.Compile<ObjectContext, int>(ctx => Dbset.Count());
            return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext);
        }

        public int GetTotalRegistros(FilterClientes filter)
        {
            var query = Dbset.Include("EV_INSCRICAO").Where(x =>
             (x.NOME.Contains(filter.Nome) || filter.Nome == null)
           && (x.NOME.StartsWith(filter.Letra) || filter.Letra == null)
           && (x.INSTITUICAO.Contains(filter.Instituicao) || filter.Instituicao == null)
           && (x.SEXO.Contains(filter.Sexo) || filter.Sexo == null)
           && (x.TEL_CELULAR.Contains(filter.Telcelular) || filter.Telcelular == null)
           && (x.CPF.StartsWith(filter.Cpf) || filter.Cpf == null)
           && (x.EMAIL.Contains(filter.Email) || filter.Email == null)
           && (x.CIDADE.Contains(filter.Cidade) || filter.Cidade == null)
           && (x.DTNASCIMENTO == filter.Dtaniversario || filter.Dtaniversario == null)
           && (x.EV_INSCRICAO.Any(y => y.EVENTOID == filter.Eventoid) || filter.Eventoid == null || filter.Eventoid == 0));

            var _object = CompiledQuery.Compile<ObjectContext, int>(ctx => query.Count());
            return _object.Invoke(((IObjectContextAdapter)Entities).ObjectContext);
        }
    }
}