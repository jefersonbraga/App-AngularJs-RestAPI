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
      /// Public Service Class  AspNetUsersService
      /// </summary>
      public partial class AspNetUsersService : BaseServices, IAspNetUsersService
      {

		public AspNetUsersService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity AspNetUsers
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<AspNetUsers> entity)
        {
            UnitOfWork.AspNetUsersRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity AspNetUsers
        /// </summary>
        /// <param name="entity"></param>
		public void Add(AspNetUsers entity)
        {	
            UnitOfWork.AspNetUsersRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity AspNetUsers
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(AspNetUsers entity)
        {
            UnitOfWork.AspNetUsersRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity AspNetUsers
        /// </summary>
        /// <returns>IEnumerable AspNetUsers</returns>
        public IEnumerable<AspNetUsers> GetAll()
        {
			return UnitOfWork.AspNetUsersRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity AspNetUsers
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AspNetUsers entity)
        {
            UnitOfWork.AspNetUsersRepository.Edit(entity);
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
        /// Get Entity AspNetUsers By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AspNetUsers</returns>
		public AspNetUsers GetById(int id)
        {
			return UnitOfWork.AspNetUsersRepository.FindBy(x => x.Id.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<AspNetUsers> FindBy(Expression<Func<AspNetUsers, bool>> predicate)
        {
            return UnitOfWork.AspNetUsersRepository.FindBy(predicate);
        }
      }
}
