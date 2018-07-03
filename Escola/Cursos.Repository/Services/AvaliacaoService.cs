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
      /// Public Service Class  AvaliacaoService
      /// </summary>
      public partial class AvaliacaoService : BaseServices, IAvaliacaoService
      {

		public AvaliacaoService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_AVALIACAO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_AVALIACAO> entity)
        {
            UnitOfWork.AvaliacaoRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_AVALIACAO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_AVALIACAO entity)
        {	
            UnitOfWork.AvaliacaoRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_AVALIACAO
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_AVALIACAO entity)
        {
            UnitOfWork.AvaliacaoRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_AVALIACAO
        /// </summary>
        /// <returns>IEnumerable EV_AVALIACAO</returns>
        public IEnumerable<EV_AVALIACAO> GetAll()
        {
			return UnitOfWork.AvaliacaoRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_AVALIACAO
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_AVALIACAO entity)
        {
            UnitOfWork.AvaliacaoRepository.Edit(entity);
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
        /// Get Entity EV_AVALIACAO By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_AVALIACAO</returns>
		public EV_AVALIACAO GetById(int id)
        {
			return UnitOfWork.AvaliacaoRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_AVALIACAO> FindBy(Expression<Func<EV_AVALIACAO, bool>> predicate)
        {
            return UnitOfWork.AvaliacaoRepository.FindBy(predicate);
        }
      }
}
