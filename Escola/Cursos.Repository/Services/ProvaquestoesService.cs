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
      /// Public Service Class  ProvaquestoesService
      /// </summary>
      public partial class ProvaquestoesService : BaseServices, IProvaquestoesService
      {

		public ProvaquestoesService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_PROVAQUESTOES
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_PROVAQUESTOES> entity)
        {
            UnitOfWork.ProvaquestoesRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_PROVAQUESTOES
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_PROVAQUESTOES entity)
        {	
            UnitOfWork.ProvaquestoesRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_PROVAQUESTOES
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_PROVAQUESTOES entity)
        {
            UnitOfWork.ProvaquestoesRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_PROVAQUESTOES
        /// </summary>
        /// <returns>IEnumerable EV_PROVAQUESTOES</returns>
        public IEnumerable<EV_PROVAQUESTOES> GetAll()
        {
			return UnitOfWork.ProvaquestoesRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_PROVAQUESTOES
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_PROVAQUESTOES entity)
        {
            UnitOfWork.ProvaquestoesRepository.Edit(entity);
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
        /// Get Entity EV_PROVAQUESTOES By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_PROVAQUESTOES</returns>
		public EV_PROVAQUESTOES GetById(int id)
        {
			return UnitOfWork.ProvaquestoesRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_PROVAQUESTOES> FindBy(Expression<Func<EV_PROVAQUESTOES, bool>> predicate)
        {
            return UnitOfWork.ProvaquestoesRepository.FindBy(predicate);
        }
      }
}
