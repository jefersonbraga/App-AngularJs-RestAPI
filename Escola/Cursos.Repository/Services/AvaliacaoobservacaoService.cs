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
      /// Public Service Class  AvaliacaoobservacaoService
      /// </summary>
      public partial class AvaliacaoobservacaoService : BaseServices, IAvaliacaoobservacaoService
      {

		public AvaliacaoobservacaoService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_AVALIACAOOBSERVACAO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_AVALIACAOOBSERVACAO> entity)
        {
            UnitOfWork.AvaliacaoobservacaoRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_AVALIACAOOBSERVACAO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_AVALIACAOOBSERVACAO entity)
        {	
            UnitOfWork.AvaliacaoobservacaoRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_AVALIACAOOBSERVACAO
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_AVALIACAOOBSERVACAO entity)
        {
            UnitOfWork.AvaliacaoobservacaoRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_AVALIACAOOBSERVACAO
        /// </summary>
        /// <returns>IEnumerable EV_AVALIACAOOBSERVACAO</returns>
        public IEnumerable<EV_AVALIACAOOBSERVACAO> GetAll()
        {
			return UnitOfWork.AvaliacaoobservacaoRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_AVALIACAOOBSERVACAO
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_AVALIACAOOBSERVACAO entity)
        {
            UnitOfWork.AvaliacaoobservacaoRepository.Edit(entity);
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
        /// Get Entity EV_AVALIACAOOBSERVACAO By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_AVALIACAOOBSERVACAO</returns>
		public EV_AVALIACAOOBSERVACAO GetById(int id)
        {
			return UnitOfWork.AvaliacaoobservacaoRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_AVALIACAOOBSERVACAO> FindBy(Expression<Func<EV_AVALIACAOOBSERVACAO, bool>> predicate)
        {
            return UnitOfWork.AvaliacaoobservacaoRepository.FindBy(predicate);
        }
      }
}
