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
      /// Public Service Class  DivulgacaoService
      /// </summary>
      public partial class DivulgacaoService : BaseServices, IDivulgacaoService
      {

		public DivulgacaoService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_DIVULGACAO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_DIVULGACAO> entity)
        {
            UnitOfWork.DivulgacaoRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_DIVULGACAO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_DIVULGACAO entity)
        {	
            UnitOfWork.DivulgacaoRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_DIVULGACAO
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_DIVULGACAO entity)
        {
            UnitOfWork.DivulgacaoRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_DIVULGACAO
        /// </summary>
        /// <returns>IEnumerable EV_DIVULGACAO</returns>
        public IEnumerable<EV_DIVULGACAO> GetAll()
        {
			return UnitOfWork.DivulgacaoRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_DIVULGACAO
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_DIVULGACAO entity)
        {
            UnitOfWork.DivulgacaoRepository.Edit(entity);
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
        /// Get Entity EV_DIVULGACAO By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_DIVULGACAO</returns>
		public EV_DIVULGACAO GetById(int id)
        {
			return UnitOfWork.DivulgacaoRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_DIVULGACAO> FindBy(Expression<Func<EV_DIVULGACAO, bool>> predicate)
        {
            return UnitOfWork.DivulgacaoRepository.FindBy(predicate);
        }
      }
}
