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
      /// Public Service Class  SalalocalprovaService
      /// </summary>
      public partial class SalalocalprovaService : BaseServices, ISalalocalprovaService
      {

		public SalalocalprovaService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_SALALOCALPROVA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_SALALOCALPROVA> entity)
        {
            UnitOfWork.SalalocalprovaRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_SALALOCALPROVA
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_SALALOCALPROVA entity)
        {	
            UnitOfWork.SalalocalprovaRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_SALALOCALPROVA
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_SALALOCALPROVA entity)
        {
            UnitOfWork.SalalocalprovaRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_SALALOCALPROVA
        /// </summary>
        /// <returns>IEnumerable EV_SALALOCALPROVA</returns>
        public IEnumerable<EV_SALALOCALPROVA> GetAll()
        {
			return UnitOfWork.SalalocalprovaRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_SALALOCALPROVA
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_SALALOCALPROVA entity)
        {
            UnitOfWork.SalalocalprovaRepository.Edit(entity);
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
        /// Get Entity EV_SALALOCALPROVA By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_SALALOCALPROVA</returns>
		public EV_SALALOCALPROVA GetById(int id)
        {
			return UnitOfWork.SalalocalprovaRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_SALALOCALPROVA> FindBy(Expression<Func<EV_SALALOCALPROVA, bool>> predicate)
        {
            return UnitOfWork.SalalocalprovaRepository.FindBy(predicate);
        }
      }
}
