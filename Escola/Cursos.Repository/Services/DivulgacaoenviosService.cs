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
      /// Public Service Class  DivulgacaoenviosService
      /// </summary>
      public partial class DivulgacaoenviosService : BaseServices, IDivulgacaoenviosService
      {

		public DivulgacaoenviosService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_DIVULGACAOENVIOS
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_DIVULGACAOENVIOS> entity)
        {
            UnitOfWork.DivulgacaoenviosRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_DIVULGACAOENVIOS
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_DIVULGACAOENVIOS entity)
        {	
            UnitOfWork.DivulgacaoenviosRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_DIVULGACAOENVIOS
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_DIVULGACAOENVIOS entity)
        {
            UnitOfWork.DivulgacaoenviosRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_DIVULGACAOENVIOS
        /// </summary>
        /// <returns>IEnumerable EV_DIVULGACAOENVIOS</returns>
        public IEnumerable<EV_DIVULGACAOENVIOS> GetAll()
        {
			return UnitOfWork.DivulgacaoenviosRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_DIVULGACAOENVIOS
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_DIVULGACAOENVIOS entity)
        {
            UnitOfWork.DivulgacaoenviosRepository.Edit(entity);
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
        /// Get Entity EV_DIVULGACAOENVIOS By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_DIVULGACAOENVIOS</returns>
		public EV_DIVULGACAOENVIOS GetById(int id)
        {
			return UnitOfWork.DivulgacaoenviosRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_DIVULGACAOENVIOS> FindBy(Expression<Func<EV_DIVULGACAOENVIOS, bool>> predicate)
        {
            return UnitOfWork.DivulgacaoenviosRepository.FindBy(predicate);
        }
      }
}
