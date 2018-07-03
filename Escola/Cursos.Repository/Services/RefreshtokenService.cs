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
      /// Public Service Class  RefreshtokenService
      /// </summary>
      public partial class RefreshtokenService : BaseServices, IRefreshtokenService
      {

		public RefreshtokenService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity AD_REFRESHTOKEN
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<AD_REFRESHTOKEN> entity)
        {
            UnitOfWork.RefreshtokenRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity AD_REFRESHTOKEN
        /// </summary>
        /// <param name="entity"></param>
		public void Add(AD_REFRESHTOKEN entity)
        {	
            UnitOfWork.RefreshtokenRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity AD_REFRESHTOKEN
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AD_REFRESHTOKEN entity)
        {
            UnitOfWork.RefreshtokenRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity AD_REFRESHTOKEN
        /// </summary>
        /// <returns>IEnumerable AD_REFRESHTOKEN</returns>
        public IEnumerable<AD_REFRESHTOKEN> GetAll()
        {
			return UnitOfWork.RefreshtokenRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity AD_REFRESHTOKEN
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AD_REFRESHTOKEN entity)
        {
            UnitOfWork.RefreshtokenRepository.Edit(entity);
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
        /// Get Entity AD_REFRESHTOKEN By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AD_REFRESHTOKEN</returns>
		public AD_REFRESHTOKEN GetById(int id)
        {
			return UnitOfWork.RefreshtokenRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<AD_REFRESHTOKEN> FindBy(Expression<Func<AD_REFRESHTOKEN, bool>> predicate)
        {
            return UnitOfWork.RefreshtokenRepository.FindBy(predicate);
        }
      }
}
