using Cursos.Repository.Work;
using Cursos.Repository.Work.Interface;

namespace Cursos.Repository.Services.Base
{
    /// <summary>
    /// Public class BaseServices
    /// </summary>
    public class BaseServices
    {
        /// <summary>
        /// Readonly UnitOfWork
        /// </summary>
        public IUnitOfWork UnitOfWork;

        //public BaseServices(IUnitOfWork unitOfWork)
        //{
        //    UnitOfWork = unitOfWork;
        //}
    }
}