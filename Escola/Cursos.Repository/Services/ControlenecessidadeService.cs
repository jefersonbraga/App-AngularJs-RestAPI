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
      /// Public Service Class  ControlenecessidadeService
      /// </summary>
      public partial class ControlenecessidadeService : BaseServices, IControlenecessidadeService
      {

		public ControlenecessidadeService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_CONTROLENECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_CONTROLENECESSIDADE> entity)
        {
            UnitOfWork.ControlenecessidadeRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_CONTROLENECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_CONTROLENECESSIDADE entity)
        {	
            UnitOfWork.ControlenecessidadeRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_CONTROLENECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_CONTROLENECESSIDADE entity)
        {
            UnitOfWork.ControlenecessidadeRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_CONTROLENECESSIDADE
        /// </summary>
        /// <returns>IEnumerable EV_CONTROLENECESSIDADE</returns>
        public IEnumerable<EV_CONTROLENECESSIDADE> GetAll()
        {
			return UnitOfWork.ControlenecessidadeRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_CONTROLENECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_CONTROLENECESSIDADE entity)
        {
            UnitOfWork.ControlenecessidadeRepository.Edit(entity);
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
        /// Get Entity EV_CONTROLENECESSIDADE By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_CONTROLENECESSIDADE</returns>
		public EV_CONTROLENECESSIDADE GetById(int id)
        {
			return UnitOfWork.ControlenecessidadeRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_CONTROLENECESSIDADE> FindBy(Expression<Func<EV_CONTROLENECESSIDADE, bool>> predicate)
        {
            return UnitOfWork.ControlenecessidadeRepository.FindBy(predicate);
        }
      }
}
