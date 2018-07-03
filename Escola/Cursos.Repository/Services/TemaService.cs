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
      /// Public Service Class  TemaService
      /// </summary>
      public partial class TemaService : BaseServices, ITemaService
      {

		public TemaService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_TEMA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_TEMA> entity)
        {
            UnitOfWork.TemaRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_TEMA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_TEMA entity)
        {	
            UnitOfWork.TemaRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_TEMA
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_TEMA entity)
        {
            UnitOfWork.TemaRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_TEMA
        /// </summary>
        /// <returns>IEnumerable EV_TEMA</returns>
        public IEnumerable<EV_TEMA> GetAll()
        {
			return UnitOfWork.TemaRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_TEMA
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_TEMA entity)
        {
            UnitOfWork.TemaRepository.Edit(entity);
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
        /// Get Entity EV_TEMA By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_TEMA</returns>
		public EV_TEMA GetById(int id)
        {
			return UnitOfWork.TemaRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_TEMA> FindBy(Expression<Func<EV_TEMA, bool>> predicate)
        {
            return UnitOfWork.TemaRepository.FindBy(predicate);
        }
      }
}
