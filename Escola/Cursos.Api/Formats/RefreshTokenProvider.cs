using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
using Cursos.Business;
using Cursos.Business.Interfaces;
using Cursos.Repository.Services;
using Cursos.Repository.Work;
using Cursos.ViewModel;

namespace Cursos.Api.Formats
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        private IRefreshtokenBusiness m_RefreshtokenBusiness;

        public RefreshTokenProvider(IRefreshtokenBusiness refreshtokenBusiness)
        {
            m_RefreshtokenBusiness = refreshtokenBusiness;
        }

        public RefreshTokenProvider()
        {
            m_RefreshtokenBusiness = new RefreshtokenBusiness(new RefreshtokenService(new UnitOfWork(new Data.Context.WescolaContext())));
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            try
            {
                var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

                //if (string.IsNullOrEmpty(clientid)) throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience client_id"); ;

                var refreshTokenId = Guid.NewGuid().ToString("n");

                //if (audience == null) throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience client_id");

                //if (audience.ResourceValues == null) throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience values not set");

                //var idUser = context.Ticket.Identity.Claims.Where(c => c.Type == "Id").FirstOrDefault();
                //if (idUser == null) throw new InvalidOperationException("AuthenticationTicket.Properties does not include id user");

                //var refreshTokenLifeTime = audience.ResourceValues.FirstOrDefault().Expires;
                var idUser = context.Ticket.Identity.Claims.Where(c => c.Type == "Id").FirstOrDefault();
                var token = new RefreshtokenViewModel()
                {
                    Userid = idUser.Value,
                    Hash = refreshTokenId,
                    Dtemissao = DateTime.Now,
                    Dtemissaoutc = DateTime.UtcNow,
                    Dtexpiracao = DateTime.Now.AddMinutes(Convert.ToDouble(10)),
                    Dtexpiracaoutc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(10)),
                };

                context.Ticket.Properties.IssuedUtc = DateTime.UtcNow;
                context.Ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddMinutes(60);
                token.Protectedticket = context.SerializeTicket();
                var result = m_RefreshtokenBusiness.Add(token);
                if (result > 0)
                    context.SetToken(refreshTokenId);
                else
                    throw new InvalidOperationException("Erro ao gravar informacao refresh token.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format("Error Serialize Ticket: {0}, innerEx: {1}", ex.Message, ex.InnerException));
            }
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            //string hashedTokenId = Business.Helper.GetHash(context.Token);

            //using (AuthRepository _repo = new AuthRepository())
            //{
            //var refreshToken = await m_RefreshTokenBusiness.FindRefreshTokenAsync(hashedTokenId);

            //if (refreshToken != null)
            //{
            //    //Get protectedTicket from refreshToken class
            //    context.DeserializeTicket(refreshToken.ProtectedTicket);
            //    //var result = await m_RefreshTokenBusiness.RemoveRefreshToken(hashedTokenId);
            //}
            //}
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }
    }
}