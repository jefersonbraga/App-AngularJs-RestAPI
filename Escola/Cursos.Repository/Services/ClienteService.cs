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
      /// Public Service Class  ClienteService
      /// </summary>
      public partial class ClienteService : BaseServices, IClienteService
      {

		public ClienteService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_CLIENTE
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_CLIENTE> entity)
        {
            UnitOfWork.ClienteRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_CLIENTE
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_CLIENTE entity)
        {	
            UnitOfWork.ClienteRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_CLIENTE
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_CLIENTE entity)
        {
            UnitOfWork.ClienteRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_CLIENTE
        /// </summary>
        /// <returns>IEnumerable EV_CLIENTE</returns>
        public IEnumerable<EV_CLIENTE> GetAll()
        {
			return UnitOfWork.ClienteRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_CLIENTE
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_CLIENTE entity)
        {
            UnitOfWork.ClienteRepository.Edit(entity);
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
        /// Get Entity EV_CLIENTE By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_CLIENTE</returns>
		public EV_CLIENTE GetById(int id)
        {
			return UnitOfWork.ClienteRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_CLIENTE> FindBy(Expression<Func<EV_CLIENTE, bool>> predicate)
        {
            return UnitOfWork.ClienteRepository.FindBy(predicate);
        }
       
    }
}
