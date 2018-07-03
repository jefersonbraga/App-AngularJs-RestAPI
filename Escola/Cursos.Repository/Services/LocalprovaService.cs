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
      /// Public Service Class  LocalprovaService
      /// </summary>
      public partial class LocalprovaService : BaseServices, ILocalprovaService
      {

		public LocalprovaService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_LOCALPROVA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_LOCALPROVA> entity)
        {
            UnitOfWork.LocalprovaRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_LOCALPROVA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_LOCALPROVA entity)
        {	
            UnitOfWork.LocalprovaRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_LOCALPROVA
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_LOCALPROVA entity)
        {
            UnitOfWork.LocalprovaRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_LOCALPROVA
        /// </summary>
        /// <returns>IEnumerable EV_LOCALPROVA</returns>
        public IEnumerable<EV_LOCALPROVA> GetAll()
        {
			return UnitOfWork.LocalprovaRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_LOCALPROVA
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_LOCALPROVA entity)
        {
            UnitOfWork.LocalprovaRepository.Edit(entity);
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
        /// Get Entity EV_LOCALPROVA By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_LOCALPROVA</returns>
		public EV_LOCALPROVA GetById(int id)
        {
			return UnitOfWork.LocalprovaRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_LOCALPROVA> FindBy(Expression<Func<EV_LOCALPROVA, bool>> predicate)
        {
            return UnitOfWork.LocalprovaRepository.FindBy(predicate);
        }
      }
}
