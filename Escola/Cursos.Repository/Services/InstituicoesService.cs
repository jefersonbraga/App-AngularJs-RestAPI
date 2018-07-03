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
      /// Public Service Class  InstituicoesService
      /// </summary>
      public partial class InstituicoesService : BaseServices, IInstituicoesService
      {

		public InstituicoesService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity ES_INSTITUICOES
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<ES_INSTITUICOES> entity)
        {
            UnitOfWork.InstituicoesRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity ES_INSTITUICOES
        /// </summary>
        /// <param name="entity"></param>
		public void Add(ES_INSTITUICOES entity)
        {	
            UnitOfWork.InstituicoesRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity ES_INSTITUICOES
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(ES_INSTITUICOES entity)
        {
            UnitOfWork.InstituicoesRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity ES_INSTITUICOES
        /// </summary>
        /// <returns>IEnumerable ES_INSTITUICOES</returns>
        public IEnumerable<ES_INSTITUICOES> GetAll()
        {
			return UnitOfWork.InstituicoesRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity ES_INSTITUICOES
        /// </summary>
        /// <param name="entity"></param>
        public void Update(ES_INSTITUICOES entity)
        {
            UnitOfWork.InstituicoesRepository.Edit(entity);
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
        /// Get Entity ES_INSTITUICOES By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ES_INSTITUICOES</returns>
		public ES_INSTITUICOES GetById(int id)
        {
			return UnitOfWork.InstituicoesRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<ES_INSTITUICOES> FindBy(Expression<Func<ES_INSTITUICOES, bool>> predicate)
        {
            return UnitOfWork.InstituicoesRepository.FindBy(predicate);
        }
      }
}
