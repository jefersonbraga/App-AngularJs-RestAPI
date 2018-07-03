using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Cursos.Api.Controllers.Base;
using Microsoft.AspNet.Identity.Owin;
using Cursos.ViewModel;
using System.Threading.Tasks;
using Cursos.Business;

namespace Cursos.Api.Controllers
{
    [RoutePrefix("services")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthenticationController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public HttpResponseMessage Authenticate(HttpRequestMessage request)
        {
            try
            {
                var body = request.Content.ReadAsStringAsync().Result;
                var data = Convert.FromBase64String(body);
                var base64Decoded = Encoding.ASCII.GetString(data);

                var viewModel = JsonConvert.DeserializeObject<AuthenticateViewModel>(base64Decoded);
                if (viewModel == null) return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error model is invalid please enter model valid");

                var result = SignInManager.PasswordSignIn(viewModel.UserName, viewModel.Password, viewModel.RememberMe, shouldLockout: false);

                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpRequestMessage().CreateErrorResponse(HttpStatusCode.InternalServerError, "Authenticate Error: " + ex.Message);
            }
        }

        // POST: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        [Route("getuser/{username}/{password}")]
        public async Task<HttpResponseMessage> GetUserAsync(string username, string password)
        {
            if (username == null || password == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error parameters is invalid please");

            var result = await UserManager.FindAsync(username, password);
            if (result != null) return Request.CreateResponse(HttpStatusCode.OK, result);
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("Erro ao listar usuario: {0}", username));
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<HttpResponseMessage> RegisterAsync(HttpRequestMessage request)
        {
            var body = request.Content.ReadAsStringAsync().Result;
            //var data = Convert.FromBase64String(body);
            //var base64Decoded = Encoding.ASCII.GetString(data);

            var viewModel = JsonConvert.DeserializeObject<AuthenticateViewModel>(body);
            if (viewModel == null) return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error model is invalid please informe model valid");

            var user = new Cursos.Business.ApplicationUser { UserName = viewModel.UserName, Email = viewModel.Email };
            var result = await UserManager.CreateAsync(user, viewModel.Password);
            if (!result.Succeeded)
            {
                var erros = string.Empty;
                foreach (var item in result.Errors) erros += item.ToString();

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("Erro ao cadastrar usuario: {0}", erros));
            }

            return Request.CreateResponse(HttpStatusCode.OK, string.Format("Registro cadastrado com sucesso: {0}", user.Id));
        }

        [Route("forget")]
        public HttpResponseMessage Forget(HttpRequestMessage request)
        {
            try
            {
                //if (request == null)
                //    return new HttpRequestMessage().CreateErrorResponse(HttpStatusCode.BadRequest, "Request is Null");

                //var body = request.Content.ReadAsStringAsync().Result;
                //var data = System.Convert.FromBase64String(body);
                //var base64Decoded = System.Text.Encoding.ASCII.GetString(data);
                //var viewModel = JsonConvert.DeserializeObject<AuthenticateViewModel>(base64Decoded);

                //if (viewModel == null)
                //    return new HttpRequestMessage().CreateErrorResponse(HttpStatusCode.BadRequest, "Object View Model is Null");

                //var result = (new RebCar.Business.Service.UsersBusinessService()).Forget(viewModel.Email);

                return null;
            }
            catch (Exception ex)
            {
                return new HttpRequestMessage().CreateErrorResponse(HttpStatusCode.InternalServerError, "Forget Error: " + ex.Message);
            }
        }
    }
}