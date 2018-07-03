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
      /// Public Service Class  LocaleventoService
      /// </summary>
      public partial class LocaleventoService : BaseServices, ILocaleventoService
      {

		public LocaleventoService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_LOCALEVENTO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_LOCALEVENTO> entity)
        {
            UnitOfWork.LocaleventoRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_LOCALEVENTO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_LOCALEVENTO entity)
        {	
            UnitOfWork.LocaleventoRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_LOCALEVENTO
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_LOCALEVENTO entity)
        {
            UnitOfWork.LocaleventoRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_LOCALEVENTO
        /// </summary>
        /// <returns>IEnumerable EV_LOCALEVENTO</returns>
        public IEnumerable<EV_LOCALEVENTO> GetAll()
        {
			return UnitOfWork.LocaleventoRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_LOCALEVENTO
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_LOCALEVENTO entity)
        {
            UnitOfWork.LocaleventoRepository.Edit(entity);
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
        /// Get Entity EV_LOCALEVENTO By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_LOCALEVENTO</returns>
		public EV_LOCALEVENTO GetById(int id)
        {
			return UnitOfWork.LocaleventoRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_LOCALEVENTO> FindBy(Expression<Func<EV_LOCALEVENTO, bool>> predicate)
        {
            return UnitOfWork.LocaleventoRepository.FindBy(predicate);
        }
      }
}
