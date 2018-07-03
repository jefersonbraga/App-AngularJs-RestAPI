using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Cursos.Api.Identity;
using Cursos.Api.Models;
using Cursos.Business;
using Cursos.Business.Interfaces;

namespace Cursos.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthenticationFilter : AuthorizeAttribute
    {
        //private readonly IResourceValuesBusiness m_ResourceValuesBusiness;
        private readonly IRefreshtokenBusiness m_RefreshTokenBusiness;
        private readonly IdentityUserManager m_IdentityUser;
        //private readonly IIdentityBusiness m_IdentityBusiness;
        private readonly bool _active = true;
        public HttpResponseMessage Response;

        public AuthenticationFilter()
        {
            ////m_ResourceValuesBusiness = new ResourceValuesBusiness();
            m_IdentityUser = new IdentityUserManager();
            //m_IdentityBusiness = new IdentityBusiness();
        }

        /// <summary>
        /// Overriden constructor to allow explicit disabling of this
        /// filter's behavior. Pass false to disable (same as no filter
        /// but declarative)
        /// </summary>
        /// <param name="active"></param>
        public AuthenticationFilter(bool active)
        {
            _active = active;
            //m_ResourceValuesBusiness = new ResourceValuesBusiness();
            //m_RefreshTokenBusiness = new RefreshTokenBusiness();
            //m_IdentityBusiness = new IdentityBusiness();
        }

        /// <summary>
        /// Override to Web API filter method to handle Basic Auth check
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            if (!_active || SkipAuthorization(actionContext)) return;
            var isAuthorised = base.IsAuthorized(actionContext);

            if (!actionContext.Request.Headers.Any(x => x.Key == "refresh_token"))
            {
                Challenge(actionContext, "Favor informar o header para requisição!");
                return;
            }

            actionContext.Request.Headers.TryGetValues("refresh_token", out IEnumerable<string> refresh_token);
            if (!isAuthorised || refresh_token == null)
            {
                Challenge(actionContext);
                return;
            }

            var principal = m_IdentityUser.GetByRefreshToken(refresh_token.FirstOrDefault());

            var identity = actionContext.Request.Headers.Authorization;

            if (identity == null || principal == null)
            {
                Challenge(actionContext);
                return;
            }

            Thread.CurrentPrincipal = principal;
            // inside of ASP.NET this is also required for some async scenarios
            if (HttpContext.Current != null)
                HttpContext.Current.User = principal;

            base.OnAuthorization(actionContext);
        }

        /// <summary>
        /// Send the Authentication Challenge request
        /// </summary>
        /// <param name="actionContext"></param>
        protected virtual void Challenge(HttpActionContext actionContext)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Usuário não autorizado");
            actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", host));
        }

        /// <summary>
        /// Send the Authentication Challenge request
        /// </summary>
        /// <param name="actionContext"></param>
        protected virtual void Challenge(HttpActionContext actionContext, string message)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, message);
            //actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", host));
        }

        private bool SkipAuthorization(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}