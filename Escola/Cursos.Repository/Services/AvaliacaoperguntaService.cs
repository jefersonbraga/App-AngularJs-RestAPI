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
      /// Public Service Class  AvaliacaoperguntaService
      /// </summary>
      public partial class AvaliacaoperguntaService : BaseServices, IAvaliacaoperguntaService
      {

		public AvaliacaoperguntaService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_AVALIACAOPERGUNTA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_AVALIACAOPERGUNTA> entity)
        {
            UnitOfWork.AvaliacaoperguntaRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_AVALIACAOPERGUNTA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_AVALIACAOPERGUNTA entity)
        {	
            UnitOfWork.AvaliacaoperguntaRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_AVALIACAOPERGUNTA
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_AVALIACAOPERGUNTA entity)
        {
            UnitOfWork.AvaliacaoperguntaRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_AVALIACAOPERGUNTA
        /// </summary>
        /// <returns>IEnumerable EV_AVALIACAOPERGUNTA</returns>
        public IEnumerable<EV_AVALIACAOPERGUNTA> GetAll()
        {
			return UnitOfWork.AvaliacaoperguntaRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_AVALIACAOPERGUNTA
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_AVALIACAOPERGUNTA entity)
        {
            UnitOfWork.AvaliacaoperguntaRepository.Edit(entity);
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
        /// Get Entity EV_AVALIACAOPERGUNTA By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_AVALIACAOPERGUNTA</returns>
		public EV_AVALIACAOPERGUNTA GetById(int id)
        {
			return UnitOfWork.AvaliacaoperguntaRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_AVALIACAOPERGUNTA> FindBy(Expression<Func<EV_AVALIACAOPERGUNTA, bool>> predicate)
        {
            return UnitOfWork.AvaliacaoperguntaRepository.FindBy(predicate);
        }
      }
}
