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
      /// Public Service Class  AcoesService
      /// </summary>
      public partial class AcoesService : BaseServices, IAcoesService
      {

		public AcoesService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity AD_ACOES
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<AD_ACOES> entity)
        {
            UnitOfWork.AcoesRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity AD_ACOES
        /// </summary>
        /// <param name="entity"></param>
		public void Add(AD_ACOES entity)
        {	
            UnitOfWork.AcoesRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity AD_ACOES
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AD_ACOES entity)
        {
            UnitOfWork.AcoesRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity AD_ACOES
        /// </summary>
        /// <returns>IEnumerable AD_ACOES</returns>
        public IEnumerable<AD_ACOES> GetAll()
        {
			return UnitOfWork.AcoesRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity AD_ACOES
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AD_ACOES entity)
        {
            UnitOfWork.AcoesRepository.Edit(entity);
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
        /// Get Entity AD_ACOES By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AD_ACOES</returns>
		public AD_ACOES GetById(int id)
        {
			return UnitOfWork.AcoesRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<AD_ACOES> FindBy(Expression<Func<AD_ACOES, bool>> predicate)
        {
            return UnitOfWork.AcoesRepository.FindBy(predicate);
        }
      }
}
