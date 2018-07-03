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
      /// Public Service Class  OrgaoemissorService
      /// </summary>
      public partial class OrgaoemissorService : BaseServices, IOrgaoemissorService
      {

		public OrgaoemissorService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity AD_ORGAOEMISSOR
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<AD_ORGAOEMISSOR> entity)
        {
            UnitOfWork.OrgaoemissorRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity AD_ORGAOEMISSOR
        /// </summary>
        /// <param name="entity"></param>
		public void Add(AD_ORGAOEMISSOR entity)
        {	
            UnitOfWork.OrgaoemissorRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity AD_ORGAOEMISSOR
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AD_ORGAOEMISSOR entity)
        {
            UnitOfWork.OrgaoemissorRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity AD_ORGAOEMISSOR
        /// </summary>
        /// <returns>IEnumerable AD_ORGAOEMISSOR</returns>
        public IEnumerable<AD_ORGAOEMISSOR> GetAll()
        {
			return UnitOfWork.OrgaoemissorRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity AD_ORGAOEMISSOR
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AD_ORGAOEMISSOR entity)
        {
            UnitOfWork.OrgaoemissorRepository.Edit(entity);
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
        /// Not Implemented By AD_ORGAOEMISSOR Not Have Attribute Id in Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AD_ORGAOEMISSOR</returns>
		public AD_ORGAOEMISSOR GetById(int id)
        {
            throw new NotImplementedException();
        }
				
		public IEnumerable<AD_ORGAOEMISSOR> FindBy(Expression<Func<AD_ORGAOEMISSOR, bool>> predicate)
        {
            return UnitOfWork.OrgaoemissorRepository.FindBy(predicate);
        }
      }
}
