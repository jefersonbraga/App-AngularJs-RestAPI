using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
[assembly: OwinStartupAttribute(typeof(Cursos.Api.Startup))]
namespace Cursos.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            UnityConfig.RegisterComponents();
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}