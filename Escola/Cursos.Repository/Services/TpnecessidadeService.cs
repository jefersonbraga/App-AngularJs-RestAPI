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
      /// Public Service Class  TpnecessidadeService
      /// </summary>
      public partial class TpnecessidadeService : BaseServices, ITpnecessidadeService
      {

		public TpnecessidadeService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_TPNECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_TPNECESSIDADE> entity)
        {
            UnitOfWork.TpnecessidadeRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_TPNECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_TPNECESSIDADE entity)
        {	
            UnitOfWork.TpnecessidadeRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_TPNECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_TPNECESSIDADE entity)
        {
            UnitOfWork.TpnecessidadeRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_TPNECESSIDADE
        /// </summary>
        /// <returns>IEnumerable EV_TPNECESSIDADE</returns>
        public IEnumerable<EV_TPNECESSIDADE> GetAll()
        {
			return UnitOfWork.TpnecessidadeRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_TPNECESSIDADE
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_TPNECESSIDADE entity)
        {
            UnitOfWork.TpnecessidadeRepository.Edit(entity);
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
        /// Get Entity EV_TPNECESSIDADE By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_TPNECESSIDADE</returns>
		public EV_TPNECESSIDADE GetById(int id)
        {
			return UnitOfWork.TpnecessidadeRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_TPNECESSIDADE> FindBy(Expression<Func<EV_TPNECESSIDADE, bool>> predicate)
        {
            return UnitOfWork.TpnecessidadeRepository.FindBy(predicate);
        }
      }
}
