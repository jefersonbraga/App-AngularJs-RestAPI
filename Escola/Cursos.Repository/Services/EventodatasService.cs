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
      /// Public Service Class  EventodatasService
      /// </summary>
      public partial class EventodatasService : BaseServices, IEventodatasService
      {

		public EventodatasService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_EVENTODATAS
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_EVENTODATAS> entity)
        {
            UnitOfWork.EventodatasRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_EVENTODATAS
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_EVENTODATAS entity)
        {	
            UnitOfWork.EventodatasRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_EVENTODATAS
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_EVENTODATAS entity)
        {
            UnitOfWork.EventodatasRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_EVENTODATAS
        /// </summary>
        /// <returns>IEnumerable EV_EVENTODATAS</returns>
        public IEnumerable<EV_EVENTODATAS> GetAll()
        {
			return UnitOfWork.EventodatasRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_EVENTODATAS
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_EVENTODATAS entity)
        {
            UnitOfWork.EventodatasRepository.Edit(entity);
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
        /// Get Entity EV_EVENTODATAS By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_EVENTODATAS</returns>
		public EV_EVENTODATAS GetById(int id)
        {
			return UnitOfWork.EventodatasRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_EVENTODATAS> FindBy(Expression<Func<EV_EVENTODATAS, bool>> predicate)
        {
            return UnitOfWork.EventodatasRepository.FindBy(predicate);
        }
      }
}
