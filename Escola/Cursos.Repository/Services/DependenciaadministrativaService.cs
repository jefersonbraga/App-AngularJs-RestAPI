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
      /// Public Service Class  DependenciaadministrativaService
      /// </summary>
      public partial class DependenciaadministrativaService : BaseServices, IDependenciaadministrativaService
      {

		public DependenciaadministrativaService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity ES_DEPENDENCIAADMINISTRATIVA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<ES_DEPENDENCIAADMINISTRATIVA> entity)
        {
            UnitOfWork.DependenciaadministrativaRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity ES_DEPENDENCIAADMINISTRATIVA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(ES_DEPENDENCIAADMINISTRATIVA entity)
        {	
            UnitOfWork.DependenciaadministrativaRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity ES_DEPENDENCIAADMINISTRATIVA
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(ES_DEPENDENCIAADMINISTRATIVA entity)
        {
            UnitOfWork.DependenciaadministrativaRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity ES_DEPENDENCIAADMINISTRATIVA
        /// </summary>
        /// <returns>IEnumerable ES_DEPENDENCIAADMINISTRATIVA</returns>
        public IEnumerable<ES_DEPENDENCIAADMINISTRATIVA> GetAll()
        {
			return UnitOfWork.DependenciaadministrativaRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity ES_DEPENDENCIAADMINISTRATIVA
        /// </summary>
        /// <param name="entity"></param>
        public void Update(ES_DEPENDENCIAADMINISTRATIVA entity)
        {
            UnitOfWork.DependenciaadministrativaRepository.Edit(entity);
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
        /// Get Entity ES_DEPENDENCIAADMINISTRATIVA By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ES_DEPENDENCIAADMINISTRATIVA</returns>
		public ES_DEPENDENCIAADMINISTRATIVA GetById(int id)
        {
			return UnitOfWork.DependenciaadministrativaRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<ES_DEPENDENCIAADMINISTRATIVA> FindBy(Expression<Func<ES_DEPENDENCIAADMINISTRATIVA, bool>> predicate)
        {
            return UnitOfWork.DependenciaadministrativaRepository.FindBy(predicate);
        }
      }
}
