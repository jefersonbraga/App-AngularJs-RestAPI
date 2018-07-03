///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/11/2017 9:23:07 PM

///// Para outros metodos implementar classe partial
///// </sumary>
using System.Data.Entity;
using Cursos.Data;
using Cursos.Repository.Base;
using Cursos.Repository.Interfaces;
namespace  Cursos.Repository
{
      public partial class EventoturnosRepository : GenericRepository<EV_EVENTOTURNOS>, IEventoturnosRepository
      {
			private DbContext _context;
			/// <summary>
			/// Construtor Object Class EV_EVENTOTURNOS
			/// </summary>
			/// <param name="context">context database</param>
			public EventoturnosRepository(DbContext context) : base(context)
			{
				_context = context;
			}
      }
}
