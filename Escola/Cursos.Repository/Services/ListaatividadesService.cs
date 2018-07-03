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
      /// Public Service Class  ListaatividadesService
      /// </summary>
      public partial class ListaatividadesService : BaseServices, IListaatividadesService
      {

		public ListaatividadesService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity ES_LISTAATIVIDADES
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<ES_LISTAATIVIDADES> entity)
        {
            UnitOfWork.ListaatividadesRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity ES_LISTAATIVIDADES
        /// </summary>
        /// <param name="entity"></param>
		public void Add(ES_LISTAATIVIDADES entity)
        {	
            UnitOfWork.ListaatividadesRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity ES_LISTAATIVIDADES
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(ES_LISTAATIVIDADES entity)
        {
            UnitOfWork.ListaatividadesRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity ES_LISTAATIVIDADES
        /// </summary>
        /// <returns>IEnumerable ES_LISTAATIVIDADES</returns>
        public IEnumerable<ES_LISTAATIVIDADES> GetAll()
        {
			return UnitOfWork.ListaatividadesRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity ES_LISTAATIVIDADES
        /// </summary>
        /// <param name="entity"></param>
        public void Update(ES_LISTAATIVIDADES entity)
        {
            UnitOfWork.ListaatividadesRepository.Edit(entity);
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
        /// Get Entity ES_LISTAATIVIDADES By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ES_LISTAATIVIDADES</returns>
		public ES_LISTAATIVIDADES GetById(int id)
        {
			return UnitOfWork.ListaatividadesRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<ES_LISTAATIVIDADES> FindBy(Expression<Func<ES_LISTAATIVIDADES, bool>> predicate)
        {
            return UnitOfWork.ListaatividadesRepository.FindBy(predicate);
        }
      }
}
