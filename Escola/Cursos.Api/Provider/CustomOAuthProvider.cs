using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Cursos.Api.Identity;
using Cursos.Business;

namespace Cursos.Api.Provider
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private IdentityUserManager m_IdentityUser;

        //private readonly IAuthenticationBusiness m_AuthenticationBusiness;
        public CustomOAuthProvider()
        {
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            //if (context.ClientId == null)
            //{
            //    context.SetError("invalid_clientId", "client_Id is not set");
            //    return Task.FromResult<object>(null);
            //}

            //var audience = m_AuthenticationBusiness.FindAudience(context.ClientId);
            //if (audience == null)
            //{
            //    context.SetError("invalid_clientId", string.Format("Invalid client_id '{0}'", context.ClientId));
            //    return Task.FromResult<object>(null);
            //}
            context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            if (context.UserName == null || context.Password == null)
            {
                context.SetError("invalid_grant", "The user name or password is not set!");
                return Task.FromResult<object>(null);
            }

            if (context.UserName.Length == 0 || context.Password.Length == 0)
            {
                context.SetError("invalid_grant", "The user name or password is not set!");
                return Task.FromResult<object>(null);
            }

            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            // Para habilitar falhas de senha para acionar o bloqueio, mude para shouldLockout: true
            var result = signinManager.PasswordSignIn(context.UserName, context.Password, false, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    m_IdentityUser = new IdentityUserManager();
                    var identity = m_IdentityUser.GetUserByUserName(context.UserName);
                    if (identity == null)
                    {
                        context.SetError("invalid_identity", "Objeto identity invalido!");
                        break;
                    }

                    var props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        {
                            "as:client_id", (context.ClientId == null) ? string.Empty : context.ClientId
                        },
                        {
                            "userName", context.UserName
                        }
                    });

                    var ticket = new AuthenticationTicket(identity, props);
                    context.Validated(ticket);

                    break;

                case SignInStatus.LockedOut:
                    context.SetError("invalid_user_lookup", "O usuario esta bloqueado!");
                    break;

                case SignInStatus.RequiresVerification:
                    context.SetError("invalid_mail", "E necessario confirmar email de cadastro!");
                    break;

                case SignInStatus.Failure:
                    context.SetError("invalid_user_or_password", "Usuario ou senha invalidos!");
                    break;

                default:
                    break;
            }
            return Task.FromResult<object>(null);
        }
    }
}