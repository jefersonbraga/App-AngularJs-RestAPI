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
      /// Public Service Class  EventoService
      /// </summary>
      public partial class EventoService : BaseServices, IEventoService
      {

		public EventoService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_EVENTO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_EVENTO> entity)
        {
            UnitOfWork.EventoRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_EVENTO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_EVENTO entity)
        {	
            UnitOfWork.EventoRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_EVENTO
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_EVENTO entity)
        {
            UnitOfWork.EventoRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_EVENTO
        /// </summary>
        /// <returns>IEnumerable EV_EVENTO</returns>
        public IEnumerable<EV_EVENTO> GetAll()
        {
			return UnitOfWork.EventoRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_EVENTO
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_EVENTO entity)
        {
            UnitOfWork.EventoRepository.Edit(entity);
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
        /// Get Entity EV_EVENTO By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_EVENTO</returns>
		public EV_EVENTO GetById(int id)
        {
			return UnitOfWork.EventoRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_EVENTO> FindBy(Expression<Func<EV_EVENTO, bool>> predicate)
        {
            return UnitOfWork.EventoRepository.FindBy(predicate);
        }
      }
}
