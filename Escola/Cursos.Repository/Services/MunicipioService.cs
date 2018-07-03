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
      /// Public Service Class  MunicipioService
      /// </summary>
      public partial class MunicipioService : BaseServices, IMunicipioService
      {

		public MunicipioService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity AD_MUNICIPIO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<AD_MUNICIPIO> entity)
        {
            UnitOfWork.MunicipioRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity AD_MUNICIPIO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(AD_MUNICIPIO entity)
        {	
            UnitOfWork.MunicipioRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity AD_MUNICIPIO
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AD_MUNICIPIO entity)
        {
            UnitOfWork.MunicipioRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity AD_MUNICIPIO
        /// </summary>
        /// <returns>IEnumerable AD_MUNICIPIO</returns>
        public IEnumerable<AD_MUNICIPIO> GetAll()
        {
			return UnitOfWork.MunicipioRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity AD_MUNICIPIO
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AD_MUNICIPIO entity)
        {
            UnitOfWork.MunicipioRepository.Edit(entity);
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
        /// Not Implemented By AD_MUNICIPIO Not Have Attribute Id in Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AD_MUNICIPIO</returns>
		public AD_MUNICIPIO GetById(int id)
        {
            throw new NotImplementedException();
        }
				
		public IEnumerable<AD_MUNICIPIO> FindBy(Expression<Func<AD_MUNICIPIO, bool>> predicate)
        {
            return UnitOfWork.MunicipioRepository.FindBy(predicate);
        }
      }
}
