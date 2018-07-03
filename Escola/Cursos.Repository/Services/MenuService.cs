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
      /// Public Service Class  MenuService
      /// </summary>
      public partial class MenuService : BaseServices, IMenuService
      {

		public MenuService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity AD_MENU
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<AD_MENU> entity)
        {
            UnitOfWork.MenuRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity AD_MENU
        /// </summary>
        /// <param name="entity"></param>
		public void Add(AD_MENU entity)
        {	
            UnitOfWork.MenuRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity AD_MENU
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AD_MENU entity)
        {
            UnitOfWork.MenuRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity AD_MENU
        /// </summary>
        /// <returns>IEnumerable AD_MENU</returns>
        public IEnumerable<AD_MENU> GetAll()
        {
			return UnitOfWork.MenuRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity AD_MENU
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AD_MENU entity)
        {
            UnitOfWork.MenuRepository.Edit(entity);
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
        /// Get Entity AD_MENU By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AD_MENU</returns>
		public AD_MENU GetById(int id)
        {
			return UnitOfWork.MenuRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<AD_MENU> FindBy(Expression<Func<AD_MENU, bool>> predicate)
        {
            return UnitOfWork.MenuRepository.FindBy(predicate);
        }
      }
}
