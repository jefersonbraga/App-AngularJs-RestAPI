
///// <sumary>
///// By: Jeferson Braga do Carmo Create Date: 25/11/2015
///// Last Update: 11/11/2017 9:24:39 PM

///// Para outros metodos implementar classe partial
///// </sumary>
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;
using Cursos.Repository.Interfaces;
using Cursos.Data.Context;
using Cursos.Repository.Work.Interface;
namespace Cursos.Repository.Work
{

	public sealed class UnitOfWork : IUnitOfWork
	{
		private readonly DbContext _dbContext;
		/// <summary>
		/// The Private Generic Repository [EV_SALALOCALPROVARepository]
		/// </summary>
		private ISalalocalprovaRepository _SalalocalprovaRepository;
		/// <summary>
		/// The Private Generic Repository [AD_MUNICIPIORepository]
		/// </summary>
		private IMunicipioRepository _MunicipioRepository;
		/// <summary>
		/// The Private Generic Repository [ES_LISTAATIVIDADESRepository]
		/// </summary>
		private IListaatividadesRepository _ListaatividadesRepository;
		/// <summary>
		/// The Private Generic Repository [AD_REFRESHTOKENRepository]
		/// </summary>
		private IRefreshtokenRepository _RefreshtokenRepository;
		/// <summary>
		/// The Private Generic Repository [AD_ACOESRepository]
		/// </summary>
		private IAcoesRepository _AcoesRepository;
		/// <summary>
		/// The Private Generic Repository [AD_MENURepository]
		/// </summary>
		private IMenuRepository _MenuRepository;
		/// <summary>
		/// The Private Generic Repository [AD_MODULOSRepository]
		/// </summary>
		private IModulosRepository _ModulosRepository;
		/// <summary>
		/// The Private Generic Repository [AD_ORGAOSRepository]
		/// </summary>
		private IOrgaosRepository _OrgaosRepository;
		/// <summary>
		/// The Private Generic Repository [AspNetUsersRepository]
		/// </summary>
		private IAspNetUsersRepository _AspNetUsersRepository;
		/// <summary>
		/// The Private Generic Repository [EV_TIPOEVENTORepository]
		/// </summary>
		private ITipoeventoRepository _TipoeventoRepository;
		/// <summary>
		/// The Private Generic Repository [EV_CONTROLENECESSIDADERepository]
		/// </summary>
		private IControlenecessidadeRepository _ControlenecessidadeRepository;
		/// <summary>
		/// The Private Generic Repository [EV_SITUACAOEVENTORepository]
		/// </summary>
		private ISituacaoeventoRepository _SituacaoeventoRepository;
		/// <summary>
		/// The Private Generic Repository [EV_CLIENTERepository]
		/// </summary>
		private IClienteRepository _ClienteRepository;
		/// <summary>
		/// The Private Generic Repository [EV_DIVULGACAORepository]
		/// </summary>
		private IDivulgacaoRepository _DivulgacaoRepository;
		/// <summary>
		/// The Private Generic Repository [EV_TPNECESSIDADERepository]
		/// </summary>
		private ITpnecessidadeRepository _TpnecessidadeRepository;
		/// <summary>
		/// The Private Generic Repository [EV_ESCOLARIDADERepository]
		/// </summary>
		private IEscolaridadeRepository _EscolaridadeRepository;
		/// <summary>
		/// The Private Generic Repository [EV_EVENTOTURNOSRepository]
		/// </summary>
		private IEventoturnosRepository _EventoturnosRepository;
		/// <summary>
		/// The Private Generic Repository [EV_NECESSIDADERepository]
		/// </summary>
		private INecessidadeRepository _NecessidadeRepository;
		/// <summary>
		/// The Private Generic Repository [EV_EVENTODATASRepository]
		/// </summary>
		private IEventodatasRepository _EventodatasRepository;
		/// <summary>
		/// The Private Generic Repository [EV_AVALIACAORepository]
		/// </summary>
		private IAvaliacaoRepository _AvaliacaoRepository;
		/// <summary>
		/// The Private Generic Repository [EV_DIVULGACAOENVIOSRepository]
		/// </summary>
		private IDivulgacaoenviosRepository _DivulgacaoenviosRepository;
		/// <summary>
		/// The Private Generic Repository [EV_LOCALEVENTORepository]
		/// </summary>
		private ILocaleventoRepository _LocaleventoRepository;
		/// <summary>
		/// The Private Generic Repository [EV_INSCRICAORepository]
		/// </summary>
		private IInscricaoRepository _InscricaoRepository;
		/// <summary>
		/// The Private Generic Repository [EV_TEMARepository]
		/// </summary>
		private ITemaRepository _TemaRepository;
		/// <summary>
		/// The Private Generic Repository [EV_AVALIACAOOBSERVACAORepository]
		/// </summary>
		private IAvaliacaoobservacaoRepository _AvaliacaoobservacaoRepository;
		/// <summary>
		/// The Private Generic Repository [EV_EVENTORepository]
		/// </summary>
		private IEventoRepository _EventoRepository;
		/// <summary>
		/// The Private Generic Repository [ES_INSTITUICOESRepository]
		/// </summary>
		private IInstituicoesRepository _InstituicoesRepository;
		/// <summary>
		/// The Private Generic Repository [AD_ORGAOEMISSORRepository]
		/// </summary>
		private IOrgaoemissorRepository _OrgaoemissorRepository;
		/// <summary>
		/// The Private Generic Repository [EV_RECURSOPROVARepository]
		/// </summary>
		private IRecursoprovaRepository _RecursoprovaRepository;
		/// <summary>
		/// The Private Generic Repository [AD_UFRepository]
		/// </summary>
		private IUfRepository _UfRepository;
		/// <summary>
		/// The Private Generic Repository [EV_GRUPODEQUESTOESRepository]
		/// </summary>
		private IGrupodequestoesRepository _GrupodequestoesRepository;
		/// <summary>
		/// The Private Generic Repository [EV_PROVAQUESTOESRepository]
		/// </summary>
		private IProvaquestoesRepository _ProvaquestoesRepository;
		/// <summary>
		/// The Private Generic Repository [EV_QUESTOESCORRECAORepository]
		/// </summary>
		private IQuestoescorrecaoRepository _QuestoescorrecaoRepository;
		/// <summary>
		/// The Private Generic Repository [EV_AVALIACAOPERGUNTARepository]
		/// </summary>
		private IAvaliacaoperguntaRepository _AvaliacaoperguntaRepository;
		/// <summary>
		/// The Private Generic Repository [EV_LOCALPROVARepository]
		/// </summary>
		private ILocalprovaRepository _LocalprovaRepository;
		/// <summary>
		/// The Private Generic Repository [ES_DEPENDENCIAADMINISTRATIVARepository]
		/// </summary>
		private IDependenciaadministrativaRepository _DependenciaadministrativaRepository;
		
		/// <summary>
		/// The Private Generic Repository [EV_SALALOCALPROVARepository]
		/// </summary>
		public ISalalocalprovaRepository SalalocalprovaRepository => _SalalocalprovaRepository ?? (_SalalocalprovaRepository = new SalalocalprovaRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [AD_MUNICIPIORepository]
		/// </summary>
		public IMunicipioRepository MunicipioRepository => _MunicipioRepository ?? (_MunicipioRepository = new MunicipioRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [ES_LISTAATIVIDADESRepository]
		/// </summary>
		public IListaatividadesRepository ListaatividadesRepository => _ListaatividadesRepository ?? (_ListaatividadesRepository = new ListaatividadesRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [AD_REFRESHTOKENRepository]
		/// </summary>
		public IRefreshtokenRepository RefreshtokenRepository => _RefreshtokenRepository ?? (_RefreshtokenRepository = new RefreshtokenRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [AD_ACOESRepository]
		/// </summary>
		public IAcoesRepository AcoesRepository => _AcoesRepository ?? (_AcoesRepository = new AcoesRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [AD_MENURepository]
		/// </summary>
		public IMenuRepository MenuRepository => _MenuRepository ?? (_MenuRepository = new MenuRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [AD_MODULOSRepository]
		/// </summary>
		public IModulosRepository ModulosRepository => _ModulosRepository ?? (_ModulosRepository = new ModulosRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [AD_ORGAOSRepository]
		/// </summary>
		public IOrgaosRepository OrgaosRepository => _OrgaosRepository ?? (_OrgaosRepository = new OrgaosRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [AspNetUsersRepository]
		/// </summary>
		public IAspNetUsersRepository AspNetUsersRepository => _AspNetUsersRepository ?? (_AspNetUsersRepository = new AspNetUsersRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_TIPOEVENTORepository]
		/// </summary>
		public ITipoeventoRepository TipoeventoRepository => _TipoeventoRepository ?? (_TipoeventoRepository = new TipoeventoRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_CONTROLENECESSIDADERepository]
		/// </summary>
		public IControlenecessidadeRepository ControlenecessidadeRepository => _ControlenecessidadeRepository ?? (_ControlenecessidadeRepository = new ControlenecessidadeRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_SITUACAOEVENTORepository]
		/// </summary>
		public ISituacaoeventoRepository SituacaoeventoRepository => _SituacaoeventoRepository ?? (_SituacaoeventoRepository = new SituacaoeventoRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_CLIENTERepository]
		/// </summary>
		public IClienteRepository ClienteRepository => _ClienteRepository ?? (_ClienteRepository = new ClienteRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_DIVULGACAORepository]
		/// </summary>
		public IDivulgacaoRepository DivulgacaoRepository => _DivulgacaoRepository ?? (_DivulgacaoRepository = new DivulgacaoRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_TPNECESSIDADERepository]
		/// </summary>
		public ITpnecessidadeRepository TpnecessidadeRepository => _TpnecessidadeRepository ?? (_TpnecessidadeRepository = new TpnecessidadeRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_ESCOLARIDADERepository]
		/// </summary>
		public IEscolaridadeRepository EscolaridadeRepository => _EscolaridadeRepository ?? (_EscolaridadeRepository = new EscolaridadeRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_EVENTOTURNOSRepository]
		/// </summary>
		public IEventoturnosRepository EventoturnosRepository => _EventoturnosRepository ?? (_EventoturnosRepository = new EventoturnosRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_NECESSIDADERepository]
		/// </summary>
		public INecessidadeRepository NecessidadeRepository => _NecessidadeRepository ?? (_NecessidadeRepository = new NecessidadeRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_EVENTODATASRepository]
		/// </summary>
		public IEventodatasRepository EventodatasRepository => _EventodatasRepository ?? (_EventodatasRepository = new EventodatasRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_AVALIACAORepository]
		/// </summary>
		public IAvaliacaoRepository AvaliacaoRepository => _AvaliacaoRepository ?? (_AvaliacaoRepository = new AvaliacaoRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_DIVULGACAOENVIOSRepository]
		/// </summary>
		public IDivulgacaoenviosRepository DivulgacaoenviosRepository => _DivulgacaoenviosRepository ?? (_DivulgacaoenviosRepository = new DivulgacaoenviosRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_LOCALEVENTORepository]
		/// </summary>
		public ILocaleventoRepository LocaleventoRepository => _LocaleventoRepository ?? (_LocaleventoRepository = new LocaleventoRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_INSCRICAORepository]
		/// </summary>
		public IInscricaoRepository InscricaoRepository => _InscricaoRepository ?? (_InscricaoRepository = new InscricaoRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_TEMARepository]
		/// </summary>
		public ITemaRepository TemaRepository => _TemaRepository ?? (_TemaRepository = new TemaRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_AVALIACAOOBSERVACAORepository]
		/// </summary>
		public IAvaliacaoobservacaoRepository AvaliacaoobservacaoRepository => _AvaliacaoobservacaoRepository ?? (_AvaliacaoobservacaoRepository = new AvaliacaoobservacaoRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_EVENTORepository]
		/// </summary>
		public IEventoRepository EventoRepository => _EventoRepository ?? (_EventoRepository = new EventoRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [ES_INSTITUICOESRepository]
		/// </summary>
		public IInstituicoesRepository InstituicoesRepository => _InstituicoesRepository ?? (_InstituicoesRepository = new InstituicoesRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [AD_ORGAOEMISSORRepository]
		/// </summary>
		public IOrgaoemissorRepository OrgaoemissorRepository => _OrgaoemissorRepository ?? (_OrgaoemissorRepository = new OrgaoemissorRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_RECURSOPROVARepository]
		/// </summary>
		public IRecursoprovaRepository RecursoprovaRepository => _RecursoprovaRepository ?? (_RecursoprovaRepository = new RecursoprovaRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [AD_UFRepository]
		/// </summary>
		public IUfRepository UfRepository => _UfRepository ?? (_UfRepository = new UfRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_GRUPODEQUESTOESRepository]
		/// </summary>
		public IGrupodequestoesRepository GrupodequestoesRepository => _GrupodequestoesRepository ?? (_GrupodequestoesRepository = new GrupodequestoesRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_PROVAQUESTOESRepository]
		/// </summary>
		public IProvaquestoesRepository ProvaquestoesRepository => _ProvaquestoesRepository ?? (_ProvaquestoesRepository = new ProvaquestoesRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_QUESTOESCORRECAORepository]
		/// </summary>
		public IQuestoescorrecaoRepository QuestoescorrecaoRepository => _QuestoescorrecaoRepository ?? (_QuestoescorrecaoRepository = new QuestoescorrecaoRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_AVALIACAOPERGUNTARepository]
		/// </summary>
		public IAvaliacaoperguntaRepository AvaliacaoperguntaRepository => _AvaliacaoperguntaRepository ?? (_AvaliacaoperguntaRepository = new AvaliacaoperguntaRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [EV_LOCALPROVARepository]
		/// </summary>
		public ILocalprovaRepository LocalprovaRepository => _LocalprovaRepository ?? (_LocalprovaRepository = new LocalprovaRepository(_dbContext));
		/// <summary>
		/// The Private Generic Repository [ES_DEPENDENCIAADMINISTRATIVARepository]
		/// </summary>
		public IDependenciaadministrativaRepository DependenciaadministrativaRepository => _DependenciaadministrativaRepository ?? (_DependenciaadministrativaRepository = new DependenciaadministrativaRepository(_dbContext));
				/// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            // Save changes with the default options
            return _dbContext.SaveChanges();
        }
		/// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public Task<int> CommitAsync()
        {
            // Save changes with the default options
            return _dbContext.SaveChangesAsync();
        }
		public UnitOfWork(WescolaContext context)
	    {
	        _dbContext = context;
			_dbContext.Configuration.LazyLoadingEnabled = false;
	    }
		public UnitOfWork()
	    {
	        _dbContext = new WescolaContext();
			_dbContext.Configuration.LazyLoadingEnabled = false;
	    }

		#region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false; 
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion
	}		
}
