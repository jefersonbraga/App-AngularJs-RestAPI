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
      /// Public Service Class  GrupodequestoesService
      /// </summary>
      public partial class GrupodequestoesService : BaseServices, IGrupodequestoesService
      {

		public GrupodequestoesService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_GRUPODEQUESTOES
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_GRUPODEQUESTOES> entity)
        {
            UnitOfWork.GrupodequestoesRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_GRUPODEQUESTOES
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_GRUPODEQUESTOES entity)
        {	
            UnitOfWork.GrupodequestoesRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_GRUPODEQUESTOES
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_GRUPODEQUESTOES entity)
        {
            UnitOfWork.GrupodequestoesRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_GRUPODEQUESTOES
        /// </summary>
        /// <returns>IEnumerable EV_GRUPODEQUESTOES</returns>
        public IEnumerable<EV_GRUPODEQUESTOES> GetAll()
        {
			return UnitOfWork.GrupodequestoesRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_GRUPODEQUESTOES
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_GRUPODEQUESTOES entity)
        {
            UnitOfWork.GrupodequestoesRepository.Edit(entity);
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
        /// Get Entity EV_GRUPODEQUESTOES By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_GRUPODEQUESTOES</returns>
		public EV_GRUPODEQUESTOES GetById(int id)
        {
			return UnitOfWork.GrupodequestoesRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_GRUPODEQUESTOES> FindBy(Expression<Func<EV_GRUPODEQUESTOES, bool>> predicate)
        {
            return UnitOfWork.GrupodequestoesRepository.FindBy(predicate);
        }
      }
}
