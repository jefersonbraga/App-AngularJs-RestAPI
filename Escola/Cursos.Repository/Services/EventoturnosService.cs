///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/11/2017 9:23:24 PM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cursos.Repository.Services.Base;
using Cursos.Data;
using Cursos.Repository.Services.Interfaces;
using System.Linq.Expressions;
using Cursos.Repository.Work.Interface;
namespace  Cursos.Repository.Services
{
	  /// <summary>
      /// Public Service Class  EventoturnosService
      /// </summary>
      public partial class EventoturnosService : BaseServices, IEventoturnosService
      {

		public EventoturnosService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_EVENTOTURNOS
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_EVENTOTURNOS> entity)
        {
            UnitOfWork.EventoturnosRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_EVENTOTURNOS
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_EVENTOTURNOS entity)
        {	
            UnitOfWork.EventoturnosRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_EVENTOTURNOS
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_EVENTOTURNOS entity)
        {
            UnitOfWork.EventoturnosRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_EVENTOTURNOS
        /// </summary>
        /// <returns>IEnumerable EV_EVENTOTURNOS</returns>
        public IEnumerable<EV_EVENTOTURNOS> GetAll()
        {
			return UnitOfWork.EventoturnosRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_EVENTOTURNOS
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_EVENTOTURNOS entity)
        {
            UnitOfWork.EventoturnosRepository.Edit(entity);
        }

		/// <summary>
        /// Commit Transaction
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            return UnitOfWork.Commit();
        }
		/// <summary>
        /// Commit Async Transaction
        /// </summary>
		public Task<int> CommitAsync()
        {
            return UnitOfWork.CommitAsync();
        }
				/// <summary>
        /// Get Entity EV_EVENTOTURNOS By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_EVENTOTURNOS</returns>
		public EV_EVENTOTURNOS GetById(int id)
        {
			return UnitOfWork.EventoturnosRepository.FindBy(x => x.IDEVENTO.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_EVENTOTURNOS> FindBy(Expression<Func<EV_EVENTOTURNOS, bool>> predicate)
        {
            return UnitOfWork.EventoturnosRepository.FindBy(predicate);
        }
      }
}
