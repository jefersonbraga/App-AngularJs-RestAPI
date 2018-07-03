namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_EVENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_EVENTO()
        {
            EV_AVALIACAO = new HashSet<EV_AVALIACAO>();
            EV_DIVULGACAOENVIOS = new HashSet<EV_DIVULGACAOENVIOS>();
            EV_EVENTODATAS = new HashSet<EV_EVENTODATAS>();
            EV_INSCRICAO = new HashSet<EV_INSCRICAO>();
            EV_RECURSOPROVA = new HashSet<EV_RECURSOPROVA>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string NOME { get; set; }

        public int? LOCALID { get; set; }

        [StringLength(50)]
        public string TP_EVENTO { get; set; }

        [StringLength(50)]
        public string SITUACAO { get; set; }

        [StringLength(50)]
        public string DISPONIVEL { get; set; }

        [StringLength(50)]
        public string EXIBIRLOCAL { get; set; }

        [StringLength(50)]
        public string INSCRICAO { get; set; }

        public int? TEMAID { get; set; }

        [Column(TypeName = "money")]
        public decimal VALOREVENTO { get; set; }

        public int? QTDVAGAS { get; set; }

        public decimal? FREQUENCIA { get; set; }

        public DateTime? DTINICIO { get; set; }

        public DateTime? DTTERMINO { get; set; }

        public TimeSpan? HORAINICIO { get; set; }

        public TimeSpan? HORATERMINO { get; set; }

        public string ENDERECO { get; set; }

        public DateTime? VECIMENTOBOLETO { get; set; }

        public string DESCRICAO { get; set; }

        public string MENSAGEMBOLETO { get; set; }

        public string MENSAGEMCOMPROVANTE { get; set; }

        public int? IDANTIGO { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTATUALIZACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_AVALIACAO> EV_AVALIACAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_DIVULGACAOENVIOS> EV_DIVULGACAOENVIOS { get; set; }

        public virtual EV_LOCALEVENTO EV_LOCALEVENTO { get; set; }

        public virtual EV_TEMA EV_TEMA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_EVENTODATAS> EV_EVENTODATAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_INSCRICAO> EV_INSCRICAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_RECURSOPROVA> EV_RECURSOPROVA { get; set; }
    }
}
