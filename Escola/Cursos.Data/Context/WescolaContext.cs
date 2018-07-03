namespace Cursos.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WescolaContext : DbContext
    {
        public WescolaContext()
            : base("name=Wescola")
        {
        }

        public virtual DbSet<AD_MUNICIPIO> AD_MUNICIPIO { get; set; }
        public virtual DbSet<AD_ORGAOEMISSOR> AD_ORGAOEMISSOR { get; set; }
        public virtual DbSet<AD_UF> AD_UF { get; set; }
        public virtual DbSet<AD_ACOES> AD_ACOES { get; set; }
        public virtual DbSet<AD_MENU> AD_MENU { get; set; }
        public virtual DbSet<AD_MODULOS> AD_MODULOS { get; set; }
        public virtual DbSet<AD_ORGAOS> AD_ORGAOS { get; set; }
        public virtual DbSet<AD_REFRESHTOKEN> AD_REFRESHTOKEN { get; set; }
        public virtual DbSet<AD_REFRESHTOKENHISTORY> AD_REFRESHTOKENHISTORY { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<EV_AVALIACAO> EV_AVALIACAO { get; set; }
        public virtual DbSet<EV_AVALIACAOOBSERVACAO> EV_AVALIACAOOBSERVACAO { get; set; }
        public virtual DbSet<EV_AVALIACAOPERGUNTA> EV_AVALIACAOPERGUNTA { get; set; }
        public virtual DbSet<EV_CLIENTE> EV_CLIENTE { get; set; }
        public virtual DbSet<EV_CONTROLENECESSIDADE> EV_CONTROLENECESSIDADE { get; set; }
        public virtual DbSet<EV_DIVULGACAO> EV_DIVULGACAO { get; set; }
        public virtual DbSet<EV_DIVULGACAOENVIOS> EV_DIVULGACAOENVIOS { get; set; }
        public virtual DbSet<EV_ESCOLARIDADE> EV_ESCOLARIDADE { get; set; }
        public virtual DbSet<EV_EVENTO> EV_EVENTO { get; set; }
        public virtual DbSet<EV_EVENTODATAS> EV_EVENTODATAS { get; set; }
        public virtual DbSet<EV_EVENTOTURNOS> EV_EVENTOTURNOS { get; set; }
        public virtual DbSet<EV_GRUPODEQUESTOES> EV_GRUPODEQUESTOES { get; set; }
        public virtual DbSet<EV_INSCRICAO> EV_INSCRICAO { get; set; }
        public virtual DbSet<EV_LOCALEVENTO> EV_LOCALEVENTO { get; set; }
        public virtual DbSet<EV_LOCALPROVA> EV_LOCALPROVA { get; set; }
        public virtual DbSet<EV_NECESSIDADE> EV_NECESSIDADE { get; set; }
        public virtual DbSet<EV_PROVAQUESTOES> EV_PROVAQUESTOES { get; set; }
        public virtual DbSet<EV_QUESTOESCORRECAO> EV_QUESTOESCORRECAO { get; set; }
        public virtual DbSet<EV_RECURSOPROVA> EV_RECURSOPROVA { get; set; }
        public virtual DbSet<EV_SALALOCALPROVA> EV_SALALOCALPROVA { get; set; }
        public virtual DbSet<EV_SITUACAOEVENTO> EV_SITUACAOEVENTO { get; set; }
        public virtual DbSet<EV_TEMA> EV_TEMA { get; set; }
        public virtual DbSet<EV_TIPOEVENTO> EV_TIPOEVENTO { get; set; }
        public virtual DbSet<EV_TPNECESSIDADE> EV_TPNECESSIDADE { get; set; }
        public virtual DbSet<ES_DEPENDENCIAADMINISTRATIVA> ES_DEPENDENCIAADMINISTRATIVA { get; set; }
        public virtual DbSet<ES_INSTITUICOES> ES_INSTITUICOES { get; set; }
        public virtual DbSet<ES_LISTAATIVIDADES> ES_LISTAATIVIDADES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AD_MUNICIPIO>()
                .Property(e => e.NO_MUNICIPIO)
                .IsUnicode(false);

            modelBuilder.Entity<AD_ORGAOEMISSOR>()
                .Property(e => e.CO_EMISSOR)
                .IsUnicode(false);

            modelBuilder.Entity<AD_ORGAOEMISSOR>()
                .Property(e => e.NO_EMISSOR)
                .IsUnicode(false);

            modelBuilder.Entity<AD_UF>()
                .Property(e => e.SG_UF)
                .IsUnicode(false);

            modelBuilder.Entity<AD_UF>()
                .Property(e => e.NO_UF)
                .IsUnicode(false);

            modelBuilder.Entity<AD_UF>()
                .Property(e => e.NO_REGIAO)
                .IsUnicode(false);

            modelBuilder.Entity<AD_UF>()
                .Property(e => e.NO_PAIS)
                .IsUnicode(false);

            modelBuilder.Entity<AD_ACOES>()
                .Property(e => e.ACOES)
                .IsUnicode(false);

            modelBuilder.Entity<AD_ACOES>()
                .Property(e => e.LINK)
                .IsUnicode(false);

            modelBuilder.Entity<AD_ACOES>()
                .Property(e => e.ICONE)
                .IsUnicode(false);

            modelBuilder.Entity<AD_ACOES>()
                .HasMany(e => e.AD_MENU)
                .WithRequired(e => e.AD_ACOES)
                .HasForeignKey(e => e.ACOESID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AD_MENU>()
                .Property(e => e.MENU)
                .IsUnicode(false);

            modelBuilder.Entity<AD_MENU>()
                .Property(e => e.LINK)
                .IsUnicode(false);

            modelBuilder.Entity<AD_MODULOS>()
                .Property(e => e.MODULO)
                .IsUnicode(false);

            modelBuilder.Entity<AD_MODULOS>()
                .HasMany(e => e.AD_ACOES)
                .WithRequired(e => e.AD_MODULOS)
                .HasForeignKey(e => e.MODULOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AD_ORGAOS>()
                .Property(e => e.ORGAO)
                .IsUnicode(false);

            modelBuilder.Entity<AD_ORGAOS>()
                .HasMany(e => e.EV_CLIENTE)
                .WithOptional(e => e.AD_ORGAOS)
                .HasForeignKey(e => e.ORGAOTRABALHOID);

            modelBuilder.Entity<AD_ORGAOS>()
                .HasMany(e => e.EV_DIVULGACAOENVIOS)
                .WithOptional(e => e.AD_ORGAOS)
                .HasForeignKey(e => e.IDORGAOTRABALHO);

            modelBuilder.Entity<AD_REFRESHTOKEN>()
                .Property(e => e.HASH)
                .IsUnicode(false);

            modelBuilder.Entity<AD_REFRESHTOKEN>()
                .Property(e => e.PROTECTEDTICKET)
                .IsUnicode(false);

            modelBuilder.Entity<AD_REFRESHTOKENHISTORY>()
                .Property(e => e.HASH)
                .IsUnicode(false);

            modelBuilder.Entity<AD_REFRESHTOKENHISTORY>()
                .Property(e => e.PROTECTEDTICKET)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AD_REFRESHTOKEN)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.USERID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.ES_LISTAATIVIDADES)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.USUARIOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.EV_CLIENTE)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.USERID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_AVALIACAO>()
                .Property(e => e.TITULO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_AVALIACAO>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_AVALIACAO>()
                .Property(e => e.DISPONIVEL)
                .IsUnicode(false);

            modelBuilder.Entity<EV_AVALIACAO>()
                .HasMany(e => e.EV_AVALIACAOOBSERVACAO)
                .WithRequired(e => e.EV_AVALIACAO)
                .HasForeignKey(e => e.AVALIACAOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_AVALIACAOOBSERVACAO>()
                .Property(e => e.OBSERVACAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_AVALIACAOPERGUNTA>()
                .Property(e => e.TITULO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.RG)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.ORGAOEMISSOR)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.UFEMISSOR)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.NACIONALIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.NATURALIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.SEXO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.NOMEPAI)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.NOMEMAE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.COMPLEMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.TEL_RESIDENCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.TEL_COMERCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.TEL_CELULAR)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.SENHA)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.CAD_ADMINISTRACAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.ENVIO_SENHA)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .Property(e => e.INSTITUICAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .HasMany(e => e.EV_AVALIACAOOBSERVACAO)
                .WithRequired(e => e.EV_CLIENTE)
                .HasForeignKey(e => e.CLIENTEID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_CLIENTE>()
                .HasMany(e => e.EV_CONTROLENECESSIDADE)
                .WithOptional(e => e.EV_CLIENTE)
                .HasForeignKey(e => e.CLIENTEID);

            modelBuilder.Entity<EV_CLIENTE>()
                .HasMany(e => e.EV_INSCRICAO)
                .WithRequired(e => e.EV_CLIENTE)
                .HasForeignKey(e => e.CLIENTEID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_DIVULGACAO>()
                .Property(e => e.TITULO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_DIVULGACAO>()
                .Property(e => e.MENSAGEM)
                .IsUnicode(false);

            modelBuilder.Entity<EV_DIVULGACAO>()
                .HasMany(e => e.EV_DIVULGACAOENVIOS)
                .WithRequired(e => e.EV_DIVULGACAO)
                .HasForeignKey(e => e.IDDIVULGACAO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_DIVULGACAOENVIOS>()
                .Property(e => e.DSLETRAALFABETO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_DIVULGACAOENVIOS>()
                .Property(e => e.EMAILTESTE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_DIVULGACAOENVIOS>()
                .Property(e => e.EMAILREMETENTE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_DIVULGACAOENVIOS>()
                .Property(e => e.ASSUNTO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_ESCOLARIDADE>()
                .Property(e => e.ESCOLARIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_ESCOLARIDADE>()
                .HasMany(e => e.EV_CLIENTE)
                .WithOptional(e => e.EV_ESCOLARIDADE)
                .HasForeignKey(e => e.ESCOLARIDADEID);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.TP_EVENTO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.SITUACAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.DISPONIVEL)
                .IsUnicode(false);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.EXIBIRLOCAL)
                .IsUnicode(false);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.INSCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.VALOREVENTO)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.FREQUENCIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.MENSAGEMBOLETO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_EVENTO>()
                .Property(e => e.MENSAGEMCOMPROVANTE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_EVENTO>()
                .HasMany(e => e.EV_AVALIACAO)
                .WithRequired(e => e.EV_EVENTO)
                .HasForeignKey(e => e.EVENTOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_EVENTO>()
                .HasMany(e => e.EV_DIVULGACAOENVIOS)
                .WithOptional(e => e.EV_EVENTO)
                .HasForeignKey(e => e.IDEVENTO);

            modelBuilder.Entity<EV_EVENTO>()
                .HasMany(e => e.EV_EVENTODATAS)
                .WithRequired(e => e.EV_EVENTO)
                .HasForeignKey(e => e.IDEVENTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_EVENTO>()
                .HasMany(e => e.EV_INSCRICAO)
                .WithRequired(e => e.EV_EVENTO)
                .HasForeignKey(e => e.EVENTOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_EVENTO>()
                .HasMany(e => e.EV_RECURSOPROVA)
                .WithRequired(e => e.EV_EVENTO)
                .HasForeignKey(e => e.EVENTOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_GRUPODEQUESTOES>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_GRUPODEQUESTOES>()
                .HasMany(e => e.EV_PROVAQUESTOES)
                .WithRequired(e => e.EV_GRUPODEQUESTOES)
                .HasForeignKey(e => e.GRUPOQUESTOESID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_GRUPODEQUESTOES>()
                .HasMany(e => e.EV_QUESTOESCORRECAO)
                .WithRequired(e => e.EV_GRUPODEQUESTOES)
                .HasForeignKey(e => e.GRUPOQUESTOESID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.VALOR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.FORMAPAGAMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.PAGO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.BOLETOEMITIDO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.VALORRECEBIDO)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.TURNO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.CARGO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.SALA)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.FASE01)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.FASE02)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.FASE03)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.FASE04)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .Property(e => e.BAIXA)
                .IsUnicode(false);

            modelBuilder.Entity<EV_INSCRICAO>()
                .HasMany(e => e.EV_CONTROLENECESSIDADE)
                .WithOptional(e => e.EV_INSCRICAO)
                .HasForeignKey(e => e.INCRICAOID);

            modelBuilder.Entity<EV_LOCALEVENTO>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_LOCALEVENTO>()
                .HasMany(e => e.EV_EVENTO)
                .WithOptional(e => e.EV_LOCALEVENTO)
                .HasForeignKey(e => e.LOCALID);

            modelBuilder.Entity<EV_LOCALPROVA>()
                .Property(e => e.LOCAL)
                .IsUnicode(false);

            modelBuilder.Entity<EV_LOCALPROVA>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<EV_LOCALPROVA>()
                .Property(e => e.LOGRADOURO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_LOCALPROVA>()
                .Property(e => e.ENDERECO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_LOCALPROVA>()
                .Property(e => e.BAIRRO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_LOCALPROVA>()
                .Property(e => e.COMPLEMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_LOCALPROVA>()
                .Property(e => e.CIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_LOCALPROVA>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_LOCALPROVA>()
                .HasMany(e => e.EV_SALALOCALPROVA)
                .WithOptional(e => e.EV_LOCALPROVA)
                .HasForeignKey(e => e.LOCALPROVAID);

            modelBuilder.Entity<EV_NECESSIDADE>()
                .Property(e => e.NECESSIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_NECESSIDADE>()
                .HasMany(e => e.EV_CONTROLENECESSIDADE)
                .WithOptional(e => e.EV_NECESSIDADE)
                .HasForeignKey(e => e.NECESSIDADEID);

            modelBuilder.Entity<EV_PROVAQUESTOES>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_RECURSOPROVA>()
                .Property(e => e.TITULO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_RECURSOPROVA>()
                .Property(e => e.INSTRUCOES)
                .IsUnicode(false);

            modelBuilder.Entity<EV_RECURSOPROVA>()
                .HasMany(e => e.EV_GRUPODEQUESTOES)
                .WithRequired(e => e.EV_RECURSOPROVA)
                .HasForeignKey(e => e.RECURSOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EV_SALALOCALPROVA>()
                .Property(e => e.SALA)
                .IsUnicode(false);

            modelBuilder.Entity<EV_SITUACAOEVENTO>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_TEMA>()
                .Property(e => e.TEMA)
                .IsUnicode(false);

            modelBuilder.Entity<EV_TEMA>()
                .HasMany(e => e.EV_EVENTO)
                .WithOptional(e => e.EV_TEMA)
                .HasForeignKey(e => e.TEMAID);

            modelBuilder.Entity<EV_TIPOEVENTO>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<EV_TPNECESSIDADE>()
                .Property(e => e.TIPONECESSIDADE)
                .IsUnicode(false);

            modelBuilder.Entity<EV_TPNECESSIDADE>()
                .HasMany(e => e.EV_NECESSIDADE)
                .WithOptional(e => e.EV_TPNECESSIDADE)
                .HasForeignKey(e => e.TIPONECESSIDADEID);

            modelBuilder.Entity<ES_DEPENDENCIAADMINISTRATIVA>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<ES_DEPENDENCIAADMINISTRATIVA>()
                .HasMany(e => e.ES_INSTITUICOES)
                .WithRequired(e => e.ES_DEPENDENCIAADMINISTRATIVA)
                .HasForeignKey(e => e.DPADMID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ES_INSTITUICOES>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<ES_INSTITUICOES>()
                .Property(e => e.SIGLA)
                .IsUnicode(false);

            modelBuilder.Entity<ES_INSTITUICOES>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<ES_LISTAATIVIDADES>()
                .Property(e => e.DESCRICAO)
                .IsUnicode(false);
        }
    }
}