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
      /// Public Service Class  EscolaridadeService
      /// </summary>
      public partial class EscolaridadeService : BaseServices, IEscolaridadeService
      {

		public EscolaridadeService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_ESCOLARIDADE
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_ESCOLARIDADE> entity)
        {
            UnitOfWork.EscolaridadeRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_ESCOLARIDADE
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_ESCOLARIDADE entity)
        {	
            UnitOfWork.EscolaridadeRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_ESCOLARIDADE
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_ESCOLARIDADE entity)
        {
            UnitOfWork.EscolaridadeRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_ESCOLARIDADE
        /// </summary>
        /// <returns>IEnumerable EV_ESCOLARIDADE</returns>
        public IEnumerable<EV_ESCOLARIDADE> GetAll()
        {
			return UnitOfWork.EscolaridadeRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_ESCOLARIDADE
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_ESCOLARIDADE entity)
        {
            UnitOfWork.EscolaridadeRepository.Edit(entity);
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
        /// Get Entity EV_ESCOLARIDADE By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_ESCOLARIDADE</returns>
		public EV_ESCOLARIDADE GetById(int id)
        {
			return UnitOfWork.EscolaridadeRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_ESCOLARIDADE> FindBy(Expression<Func<EV_ESCOLARIDADE, bool>> predicate)
        {
            return UnitOfWork.EscolaridadeRepository.FindBy(predicate);
        }
      }
}
