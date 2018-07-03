using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Cursos.Api.Models;
using System.Security.Claims;
using Cursos.Business.Interfaces;
using Cursos.Business;
using Cursos.Repository.Services;
using Cursos.Repository.Work;

namespace Cursos.Api.Identity
{
    public class IdentityUserManager : IIdentityUserManager
    {
        private readonly IAspNetUsersBusiness m_AspNetUsersBusiness;
        //private readonly IPersonService m_PersonService;
        //private readonly ISecurityService m_SecurityService;

        public IdentityUserManager()
        {
            m_AspNetUsersBusiness = new AspNetUsersBusiness(new AspNetUsersService(new UnitOfWork(new Data.Context.WescolaContext())));
        }

        public ClaimsIdentity GetUserByUserName(string username)
        {
            using (var obj = new AspNetUsersBusiness()) {
                var user = obj.GetUserByName(username);

                if (user != null)
                {
                    var identity = new ClaimsIdentity("OAuthBearer");
                    identity.AddClaim(new Claim("Id", user.Id.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                    identity.AddClaim(new Claim("Modulo", "0"));
                    return identity;
                }
                return null;
            };
        }

        public GenericPrincipal GetByRefreshToken(string refresh_token)
        {
            using (var obj = new AspNetUsersBusiness())
            {
                var user = obj.GetByRefreshToken(refresh_token);
                if (user != null)
                {
                    var identity = new AuthenticationIdentity(user.User.Username);
                    identity.AddClaim(new Claim("Id", user.Userid.ToString()));
                    identity.AddClaim(new Claim("Modulo", "0"));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.User.Username));
                    return new GenericPrincipal(identity, null); ;
                }
                return null;
            }
        }
    }
}