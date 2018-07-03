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
      /// Public Service Class  ModulosService
      /// </summary>
      public partial class ModulosService : BaseServices, IModulosService
      {

		public ModulosService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity AD_MODULOS
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<AD_MODULOS> entity)
        {
            UnitOfWork.ModulosRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity AD_MODULOS
        /// </summary>
        /// <param name="entity"></param>
		public void Add(AD_MODULOS entity)
        {	
            UnitOfWork.ModulosRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity AD_MODULOS
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AD_MODULOS entity)
        {
            UnitOfWork.ModulosRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity AD_MODULOS
        /// </summary>
        /// <returns>IEnumerable AD_MODULOS</returns>
        public IEnumerable<AD_MODULOS> GetAll()
        {
			return UnitOfWork.ModulosRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity AD_MODULOS
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AD_MODULOS entity)
        {
            UnitOfWork.ModulosRepository.Edit(entity);
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
        /// Get Entity AD_MODULOS By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AD_MODULOS</returns>
		public AD_MODULOS GetById(int id)
        {
			return UnitOfWork.ModulosRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<AD_MODULOS> FindBy(Expression<Func<AD_MODULOS, bool>> predicate)
        {
            return UnitOfWork.ModulosRepository.FindBy(predicate);
        }
      }
}
