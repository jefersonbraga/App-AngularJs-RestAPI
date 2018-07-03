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
      /// Public Service Class  QuestoescorrecaoService
      /// </summary>
      public partial class QuestoescorrecaoService : BaseServices, IQuestoescorrecaoService
      {

		public QuestoescorrecaoService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_QUESTOESCORRECAO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_QUESTOESCORRECAO> entity)
        {
            UnitOfWork.QuestoescorrecaoRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_QUESTOESCORRECAO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_QUESTOESCORRECAO entity)
        {	
            UnitOfWork.QuestoescorrecaoRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_QUESTOESCORRECAO
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_QUESTOESCORRECAO entity)
        {
            UnitOfWork.QuestoescorrecaoRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_QUESTOESCORRECAO
        /// </summary>
        /// <returns>IEnumerable EV_QUESTOESCORRECAO</returns>
        public IEnumerable<EV_QUESTOESCORRECAO> GetAll()
        {
			return UnitOfWork.QuestoescorrecaoRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_QUESTOESCORRECAO
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_QUESTOESCORRECAO entity)
        {
            UnitOfWork.QuestoescorrecaoRepository.Edit(entity);
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
        /// Get Entity EV_QUESTOESCORRECAO By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_QUESTOESCORRECAO</returns>
		public EV_QUESTOESCORRECAO GetById(int id)
        {
			return UnitOfWork.QuestoescorrecaoRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_QUESTOESCORRECAO> FindBy(Expression<Func<EV_QUESTOESCORRECAO, bool>> predicate)
        {
            return UnitOfWork.QuestoescorrecaoRepository.FindBy(predicate);
        }
      }
}
