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
      /// Public Service Class  RecursoprovaService
      /// </summary>
      public partial class RecursoprovaService : BaseServices, IRecursoprovaService
      {

		public RecursoprovaService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_RECURSOPROVA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_RECURSOPROVA> entity)
        {
            UnitOfWork.RecursoprovaRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_RECURSOPROVA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_RECURSOPROVA entity)
        {	
            UnitOfWork.RecursoprovaRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_RECURSOPROVA
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_RECURSOPROVA entity)
        {
            UnitOfWork.RecursoprovaRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_RECURSOPROVA
        /// </summary>
        /// <returns>IEnumerable EV_RECURSOPROVA</returns>
        public IEnumerable<EV_RECURSOPROVA> GetAll()
        {
			return UnitOfWork.RecursoprovaRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_RECURSOPROVA
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_RECURSOPROVA entity)
        {
            UnitOfWork.RecursoprovaRepository.Edit(entity);
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
        /// Get Entity EV_RECURSOPROVA By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_RECURSOPROVA</returns>
		public EV_RECURSOPROVA GetById(int id)
        {
			return UnitOfWork.RecursoprovaRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_RECURSOPROVA> FindBy(Expression<Func<EV_RECURSOPROVA, bool>> predicate)
        {
            return UnitOfWork.RecursoprovaRepository.FindBy(predicate);
        }
      }
}
