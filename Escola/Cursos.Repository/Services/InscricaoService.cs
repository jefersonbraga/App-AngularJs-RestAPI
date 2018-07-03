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
      /// Public Service Class  InscricaoService
      /// </summary>
      public partial class InscricaoService : BaseServices, IInscricaoService
      {

		public InscricaoService(IUnitOfWork unitOfWork)
        {
			UnitOfWork = unitOfWork;
        }

		/// <summary>
        /// Add Range Entity EV_INSCRICAO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(IEnumerable<EV_INSCRICAO> entity)
        {
            UnitOfWork.InscricaoRepository.Add(entity);
        }

		/// <summary>
        /// Add Entity EV_INSCRICAO
        /// </summary>
        /// <param name="entity"></param>
		public void Add(EV_INSCRICAO entity)
        {	
            UnitOfWork.InscricaoRepository.Add(entity);
        }
		/// <summary>
        /// Delete Entity EV_INSCRICAO
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(EV_INSCRICAO entity)
        {
            UnitOfWork.InscricaoRepository.Delete(entity);
        }
		 /// <summary>
        /// Get All Entity EV_INSCRICAO
        /// </summary>
        /// <returns>IEnumerable EV_INSCRICAO</returns>
        public IEnumerable<EV_INSCRICAO> GetAll()
        {
			return UnitOfWork.InscricaoRepository.GetAll();
        }
	     
		/// <summary>
        /// Update Entity EV_INSCRICAO
        /// </summary>
        /// <param name="entity"></param>
        public void Update(EV_INSCRICAO entity)
        {
            UnitOfWork.InscricaoRepository.Edit(entity);
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
        /// Get Entity EV_INSCRICAO By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EV_INSCRICAO</returns>
		public EV_INSCRICAO GetById(int id)
        {
			return UnitOfWork.InscricaoRepository.FindBy(x => x.ID.Equals(id)).SingleOrDefault();
        }		
				
		public IEnumerable<EV_INSCRICAO> FindBy(Expression<Func<EV_INSCRICAO, bool>> predicate)
        {
            return UnitOfWork.InscricaoRepository.FindBy(predicate);
        }
      }
}
