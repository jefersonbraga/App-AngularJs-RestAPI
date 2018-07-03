using System;
using System.Threading.Tasks;
using Cursos.Repository.Interfaces;

namespace Cursos.Repository.Work.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ISalalocalprovaRepository SalalocalprovaRepository { get; }

        /// <summary>
        /// The  Generic Repository [AD_MUNICIPIORepository]
        /// </summary>
        IMunicipioRepository MunicipioRepository { get; }

        /// <summary>
        /// The  Generic Repository [AD_REFRESHTOKENRepository]
        /// </summary>
        IRefreshtokenRepository RefreshtokenRepository { get; }

        /// <summary>
        /// The  Generic Repository [ES_LISTAATIVIDADESRepository]
        /// </summary>
        IListaatividadesRepository ListaatividadesRepository { get; }

        /// <summary>
        /// The  Generic Repository [AD_ACOESRepository]
        /// </summary>
        IAcoesRepository AcoesRepository { get; }

        /// <summary>
        /// The  Generic Repository [AD_MENURepository]
        /// </summary>
        IMenuRepository MenuRepository { get; }

        /// <summary>
        /// The  Generic Repository [AD_MODULOSRepository]
        /// </summary>
        IModulosRepository ModulosRepository { get; }

        /// <summary>
        /// The  Generic Repository [AD_ORGAOSRepository]
        /// </summary>
        IOrgaosRepository OrgaosRepository { get; }

        /// <summary>
        /// The  Generic Repository [AspNetUsersRepository]
        /// </summary>
        IAspNetUsersRepository AspNetUsersRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_CONTROLENECESSIDADERepository]
        /// </summary>
        IControlenecessidadeRepository ControlenecessidadeRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_CLIENTERepository]
        /// </summary>
        IClienteRepository ClienteRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_DIVULGACAORepository]
        /// </summary>
        IDivulgacaoRepository DivulgacaoRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_TPNECESSIDADERepository]
        /// </summary>
        ITpnecessidadeRepository TpnecessidadeRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_ESCOLARIDADERepository]
        /// </summary>
        IEscolaridadeRepository EscolaridadeRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_NECESSIDADERepository]
        /// </summary>
        INecessidadeRepository NecessidadeRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_AVALIACAORepository]
        /// </summary>
        IAvaliacaoRepository AvaliacaoRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_LOCALEVENTORepository]
        /// </summary>
        ILocaleventoRepository LocaleventoRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_INSCRICAORepository]
        /// </summary>
        IInscricaoRepository InscricaoRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_TEMARepository]
        /// </summary>
        ITemaRepository TemaRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_EVENTORepository]
        /// </summary>
        IEventoRepository EventoRepository { get; }

        /// <summary>
        /// The  Generic Repository [ES_INSTITUICOESRepository]
        /// </summary>
        IInstituicoesRepository InstituicoesRepository { get; }

        /// <summary>
        /// The  Generic Repository [AD_ORGAOEMISSORRepository]
        /// </summary>
        IOrgaoemissorRepository OrgaoemissorRepository { get; }

        /// <summary>
        /// The  Generic Repository [AD_UFRepository]
        /// </summary>
        IUfRepository UfRepository { get; }

        /// <summary>
        /// The  Generic Repository [EV_LOCALPROVARepository]
        /// </summary>
        ILocalprovaRepository LocalprovaRepository { get; }

        /// <summary>
        /// The  Generic Repository [ES_DEPENDENCIAADMINISTRATIVARepository]
        /// </summary>
        IDependenciaadministrativaRepository DependenciaadministrativaRepository { get; }

        /// <summary>
        /// The Private Generic Repository [EV_SITUACAOEVENTORepository]
        /// </summary>
        ISituacaoeventoRepository SituacaoeventoRepository { get; }

        ITipoeventoRepository TipoeventoRepository { get; }

        IEventoturnosRepository EventoturnosRepository { get; }
        IEventodatasRepository EventodatasRepository { get; }

        IDivulgacaoenviosRepository DivulgacaoenviosRepository { get; }
        IAvaliacaoobservacaoRepository AvaliacaoobservacaoRepository { get; }
        IAvaliacaoperguntaRepository AvaliacaoperguntaRepository { get; }

        IRecursoprovaRepository RecursoprovaRepository { get; }
        IQuestoescorrecaoRepository QuestoescorrecaoRepository { get; }
        IGrupodequestoesRepository GrupodequestoesRepository { get; }

        IProvaquestoesRepository ProvaquestoesRepository { get; }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();

        Task<int> CommitAsync();
    }
}