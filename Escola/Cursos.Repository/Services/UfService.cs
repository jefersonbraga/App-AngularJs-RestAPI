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
      /// Public Service Class  UfService
      /// </summary>
      public partial class UfService : BaseServices, IUfService
      {

		public UfService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity AD_UF
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<AD_UF> entity)
        {
            UnitOfWork.UfRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity AD_UF
        /// </summary>
        /// <param name="entity"></param>
		public void Add(AD_UF entity)
        {	
            UnitOfWork.UfRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity AD_UF
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AD_UF entity)
        {
            UnitOfWork.UfRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity AD_UF
        /// </summary>
        /// <returns>IEnumerable AD_UF</returns>
        public IEnumerable<AD_UF> GetAll()
        {
			return UnitOfWork.UfRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity AD_UF
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AD_UF entity)
        {
            UnitOfWork.UfRepository.Edit(entity);
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
        /// Not Implemented By AD_UF Not Have Attribute Id in Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AD_UF</returns>
		public AD_UF GetById(int id)
        {
            throw new NotImplementedException();
        }
				
		public IEnumerable<AD_UF> FindBy(Expression<Func<AD_UF, bool>> predicate)
        {
            return UnitOfWork.UfRepository.FindBy(predicate);
        }
      }
}
