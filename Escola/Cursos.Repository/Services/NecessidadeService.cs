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
      /// Public Service Class  NecessidadeService
      /// </summary>
      public partial class NecessidadeService : BaseServices, INecessidadeService
      {

		public NecessidadeService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_NECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_NECESSIDADE> entity)
        {
            UnitOfWork.NecessidadeRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_NECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_NECESSIDADE entity)
        {	
            UnitOfWork.NecessidadeRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_NECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_NECESSIDADE entity)
        {
            UnitOfWork.NecessidadeRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_NECESSIDADE
        /// </summary>
        /// <returns>IEnumerable EV_NECESSIDADE</returns>
        public IEnumerable<EV_NECESSIDADE> GetAll()
        {
			return UnitOfWork.NecessidadeRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_NECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_NECESSIDADE entity)
        {
            UnitOfWork.NecessidadeRepository.Edit(entity);
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
        /// Get Entity EV_NECESSIDADE By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_NECESSIDADE</returns>
		public EV_NECESSIDADE GetById(int id)
        {
			return UnitOfWork.NecessidadeRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_NECESSIDADE> FindBy(Expression<Func<EV_NECESSIDADE, bool>> predicate)
        {
            return UnitOfWork.NecessidadeRepository.FindBy(predicate);
        }
      }
}
