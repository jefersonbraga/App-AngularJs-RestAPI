using System.Security.Claims;
using System.Security.Principal;

namespace Cursos.Api.Identity
{
    public interface IIdentityUserManager
    {
        ClaimsIdentity GetUserByUserName(string username);
        GenericPrincipal GetByRefreshToken(string refresh_token);
    }
}