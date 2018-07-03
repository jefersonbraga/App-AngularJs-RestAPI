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
      /// Public Service Class  SituacaoeventoService
      /// </summary>
      public partial class SituacaoeventoService : BaseServices, ISituacaoeventoService
      {

		public SituacaoeventoService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_SITUACAOEVENTO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_SITUACAOEVENTO> entity)
        {
            UnitOfWork.SituacaoeventoRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_SITUACAOEVENTO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_SITUACAOEVENTO entity)
        {	
            UnitOfWork.SituacaoeventoRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_SITUACAOEVENTO
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_SITUACAOEVENTO entity)
        {
            UnitOfWork.SituacaoeventoRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_SITUACAOEVENTO
        /// </summary>
        /// <returns>IEnumerable EV_SITUACAOEVENTO</returns>
        public IEnumerable<EV_SITUACAOEVENTO> GetAll()
        {
			return UnitOfWork.SituacaoeventoRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_SITUACAOEVENTO
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_SITUACAOEVENTO entity)
        {
            UnitOfWork.SituacaoeventoRepository.Edit(entity);
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
        /// Get Entity EV_SITUACAOEVENTO By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_SITUACAOEVENTO</returns>
		public EV_SITUACAOEVENTO GetById(int id)
        {
			return UnitOfWork.SituacaoeventoRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_SITUACAOEVENTO> FindBy(Expression<Func<EV_SITUACAOEVENTO, bool>> predicate)
        {
            return UnitOfWork.SituacaoeventoRepository.FindBy(predicate);
        }
      }
}
