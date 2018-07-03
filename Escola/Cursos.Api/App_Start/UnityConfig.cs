using Microsoft.Practices.Unity;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;
using Cursos.Api.Identity;
using Cursos.Api.Provider;
using Cursos.Business;
using Cursos.Business.Interfaces;
using Cursos.Data.Context;
using Cursos.Repository.Services;
using Cursos.Repository.Services.Interfaces;
using Cursos.Repository.Work;
using Cursos.Repository.Work.Interface;

namespace Cursos.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<DbContext, WescolaContext>();
            container.RegisterType<IHomeBusiness, HomeBusiness>();
            container.RegisterType<IAcoesBusiness, AcoesBusiness>();
            container.RegisterType<IMenuBusiness, MenuBusiness>();
            container.RegisterType<IAvaliacaoBusiness, AvaliacaoBusiness>();
            container.RegisterType<IClienteBusiness, ClienteBusiness>();
            container.RegisterType<IControlenecessidadeBusiness, ControlenecessidadeBusiness>();
            container.RegisterType<IDivulgacaoBusiness, DivulgacaoBusiness>();
            container.RegisterType<IEscolaridadeBusiness, EscolaridadeBusiness>();
            container.RegisterType<IEventoBusiness, EventoBusiness>();
            container.RegisterType<IInscricaoBusiness, InscricaoBusiness>();
            container.RegisterType<ILocalprovaBusiness, LocalprovaBusiness>();
            container.RegisterType<IModulosBusiness, ModulosBusiness>();
            container.RegisterType<INecessidadeBusiness, NecessidadeBusiness>();
            container.RegisterType<IOrgaosBusiness, OrgaosBusiness>();
            container.RegisterType<ISalalocalprovaBusiness, SalalocalprovaBusiness>();
            container.RegisterType<ITemaBusiness, TemaBusiness>();
            container.RegisterType<ITpnecessidadeBusiness, TpnecessidadeBusiness>();
            container.RegisterType<IUfBusiness, UfBusiness>();
            container.RegisterType<IOrgaoemissorBusiness, OrgaoemissorBusiness>();
            container.RegisterType<IMunicipioBusiness, MunicipioBusiness>();
            container.RegisterType<IRefreshtokenBusiness, RefreshtokenBusiness>();
            container.RegisterType<IAspNetUsersBusiness, AspNetUsersBusiness>();
            container.RegisterType<IIdentityUserManager, IdentityUserManager>();
            container.RegisterType<ILocaleventoBusiness, LocaleventoBusiness>();
            container.RegisterType<IInstituicoesBusiness, InstituicoesBusiness>();
            container.RegisterType<ITipoeventoBusiness, TipoeventoBusiness>();
            container.RegisterType<ISituacaoeventoBusiness, SituacaoeventoBusiness>();
            container.RegisterType<IEventoturnosBusiness, EventoturnosBusiness>();
            container.RegisterType<IEventodatasBusiness, EventodatasBusiness>();
            container.RegisterType<IDivulgacaoenviosBusiness, DivulgacaoenviosBusiness>();
            container.RegisterType<IAvaliacaoobservacaoBusiness, AvaliacaoobservacaoBusiness>();
            container.RegisterType<IAvaliacaoperguntaBusiness, AvaliacaoperguntaBusiness>();
            container.RegisterType<IGrupodequestoesBusiness, GrupodequestoesBusiness>();
            container.RegisterType<IRecursoprovaBusiness, RecursoprovaBusiness>();
            container.RegisterType<IQuestoescorrecaoBusiness, QuestoescorrecaoBusiness>();
            container.RegisterType<IProvaquestoesBusiness, ProvaquestoesBusiness>();

            container.RegisterType<IMenuService, MenuService>();
            container.RegisterType<IAcoesService, AcoesService>();
            container.RegisterType<IAvaliacaoService, AvaliacaoService>();
            container.RegisterType<IClienteService, ClienteService>();
            container.RegisterType<IControlenecessidadeService, ControlenecessidadeService>();
            container.RegisterType<IDivulgacaoService, DivulgacaoService>();
            container.RegisterType<IEscolaridadeService, EscolaridadeService>();
            container.RegisterType<IEventoService, EventoService>();
            container.RegisterType<IInscricaoService, InscricaoService>();
            container.RegisterType<ILocalprovaService, LocalprovaService>();
            container.RegisterType<IModulosService, ModulosService>();
            container.RegisterType<INecessidadeService, NecessidadeService>();
            container.RegisterType<IOrgaosService, OrgaosService>();
            container.RegisterType<ISalalocalprovaService, SalalocalprovaService>();
            container.RegisterType<ITemaService, TemaService>();
            container.RegisterType<ITpnecessidadeService, TpnecessidadeService>();
            container.RegisterType<IUfService, UfService>();
            container.RegisterType<IOrgaoemissorService, OrgaoemissorService>();
            container.RegisterType<IMunicipioService, MunicipioService>();
            container.RegisterType<IRefreshtokenService, RefreshtokenService>();
            container.RegisterType<IAspNetUsersService, AspNetUsersService>();
            container.RegisterType<ILocaleventoService, LocaleventoService>();
            container.RegisterType<IInstituicoesService, InstituicoesService>();
            container.RegisterType<ITipoeventoService, TipoeventoService>();
            container.RegisterType<ISituacaoeventoService, SituacaoeventoService>();
            container.RegisterType<IEventoturnosService, EventoturnosService>();
            container.RegisterType<IEventodatasService, EventodatasService>();
            container.RegisterType<IDivulgacaoenviosService, DivulgacaoenviosService>();
            container.RegisterType<IAvaliacaoobservacaoService, AvaliacaoobservacaoService>();
            container.RegisterType<IAvaliacaoperguntaService, AvaliacaoperguntaService>();
            container.RegisterType<IQuestoescorrecaoService, QuestoescorrecaoService>();
            container.RegisterType<IRecursoprovaService, RecursoprovaService>();
            container.RegisterType<IProvaquestoesService, ProvaquestoesService>();
            container.RegisterType<IGrupodequestoesService, GrupodequestoesService>();
            container.RegisterType<IReportingBusiness, ReportingBusiness>();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}