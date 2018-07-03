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
      /// Public Service Class  TipoeventoService
      /// </summary>
      public partial class TipoeventoService : BaseServices, ITipoeventoService
      {

		public TipoeventoService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_TIPOEVENTO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_TIPOEVENTO> entity)
        {
            UnitOfWork.TipoeventoRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_TIPOEVENTO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_TIPOEVENTO entity)
        {	
            UnitOfWork.TipoeventoRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_TIPOEVENTO
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_TIPOEVENTO entity)
        {
            UnitOfWork.TipoeventoRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_TIPOEVENTO
        /// </summary>
        /// <returns>IEnumerable EV_TIPOEVENTO</returns>
        public IEnumerable<EV_TIPOEVENTO> GetAll()
        {
			return UnitOfWork.TipoeventoRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_TIPOEVENTO
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_TIPOEVENTO entity)
        {
            UnitOfWork.TipoeventoRepository.Edit(entity);
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
        /// Get Entity EV_TIPOEVENTO By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_TIPOEVENTO</returns>
		public EV_TIPOEVENTO GetById(int id)
        {
			return UnitOfWork.TipoeventoRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_TIPOEVENTO> FindBy(Expression<Func<EV_TIPOEVENTO, bool>> predicate)
        {
            return UnitOfWork.TipoeventoRepository.FindBy(predicate);
        }
      }
}
