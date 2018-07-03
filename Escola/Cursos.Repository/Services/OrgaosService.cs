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
      /// Public Service Class  OrgaosService
      /// </summary>
      public partial class OrgaosService : BaseServices, IOrgaosService
      {

		public OrgaosService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity AD_ORGAOS
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<AD_ORGAOS> entity)
        {
            UnitOfWork.OrgaosRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity AD_ORGAOS
        /// </summary>
        /// <param name="entity"></param>
		public void Add(AD_ORGAOS entity)
        {	
            UnitOfWork.OrgaosRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity AD_ORGAOS
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AD_ORGAOS entity)
        {
            UnitOfWork.OrgaosRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity AD_ORGAOS
        /// </summary>
        /// <returns>IEnumerable AD_ORGAOS</returns>
        public IEnumerable<AD_ORGAOS> GetAll()
        {
			return UnitOfWork.OrgaosRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity AD_ORGAOS
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AD_ORGAOS entity)
        {
            UnitOfWork.OrgaosRepository.Edit(entity);
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
        /// Get Entity AD_ORGAOS By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AD_ORGAOS</returns>
		public AD_ORGAOS GetById(int id)
        {
			return UnitOfWork.OrgaosRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<AD_ORGAOS> FindBy(Expression<Func<AD_ORGAOS, bool>> predicate)
        {
            return UnitOfWork.OrgaosRepository.FindBy(predicate);
        }
      }
}
