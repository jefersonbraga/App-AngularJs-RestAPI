using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursos.Repository.Services;
using Cursos.Repository.Services.Interfaces;
using Cursos.Repository.Work;
using Cursos.ViewModel;

namespace Cursos.Business
{
    public partial class AspNetUsersBusiness : IAspNetUsersBusiness, IDisposable
    {
        private IClienteService m_ClienteServices;
        private IRefreshtokenService m_RefreshtokenService;
        public AspNetUsersBusiness(IAspNetUsersService aspNetUsersService, IClienteService clienteService, IRefreshtokenService refreshtokenService)
        {
            m_AspNetUsersService = aspNetUsersService;
            m_ClienteServices = clienteService;
            m_RefreshtokenService = refreshtokenService;
        }
        public AspNetUsersBusiness()
        {
            m_AspNetUsersService = new AspNetUsersService(new UnitOfWork(new Data.Context.WescolaContext()));
            m_ClienteServices = new ClienteService(new UnitOfWork(new Data.Context.WescolaContext()));
            m_RefreshtokenService = new RefreshtokenService(new UnitOfWork(new Data.Context.WescolaContext()));
        }
        public AspNetUsersViewModel GetUserByName(string username)
        {
            return m_AspNetUsersService.FindBy(x => x.UserName == username).Select(item=> new AspNetUsersViewModel {
                Id = item.Id,
                Email = item.Email,
                Accessfailedcount = item.AccessFailedCount,
                Username = item.UserName,
                Lockoutenabled = item.LockoutEnabled,
                Lockoutenddateutc = item.LockoutEndDateUtc,
                
            }).FirstOrDefault();
        }

        public RefreshtokenViewModel GetByRefreshToken(string refreshToken)
        {
            return m_RefreshtokenService.FindBy(x => x.HASH == refreshToken).Select(item => new RefreshtokenViewModel
            {
                Id = item.ID,
                Dtemissao = item.DTEMISSAO,
                Hash = item.HASH,
                Protectedticket = item.PROTECTEDTICKET,
                Userid = item.USERID,
                User = m_AspNetUsersService.FindBy(x=>x.Id == item.USERID).Select(user=> new AspNetUsersViewModel {
                    Id = user.Id,
                    Email = user.Email,
                    Accessfailedcount = user.AccessFailedCount,
                    Username = user.UserName,
                    Lockoutenabled = user.LockoutEnabled,
                    Lockoutenddateutc = user.LockoutEndDateUtc,
                }).FirstOrDefault(),
            }).FirstOrDefault();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
