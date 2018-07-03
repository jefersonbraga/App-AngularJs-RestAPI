namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_INSCRICAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_INSCRICAO()
        {
            EV_CONTROLENECESSIDADE = new HashSet<EV_CONTROLENECESSIDADE>();
        }

        public int ID { get; set; }

        public int CLIENTEID { get; set; }

        public int EVENTOID { get; set; }

        public int? NEESPECIALID { get; set; }

        public DateTime DTINSCRICAO { get; set; }

        [Column(TypeName = "money")]
        public decimal VALOR { get; set; }

        [StringLength(50)]
        public string FORMAPAGAMENTO { get; set; }

        [StringLength(50)]
        public string PAGO { get; set; }

        public DateTime? DTBOLETOEMITIDO { get; set; }

        [StringLength(50)]
        public string BOLETOEMITIDO { get; set; }

        public DateTime? DATAPAGAMENTO { get; set; }

        [Column(TypeName = "money")]
        public decimal? VALORRECEBIDO { get; set; }

        [StringLength(50)]
        public string TURNO { get; set; }

        [StringLength(250)]
        public string CARGO { get; set; }

        [StringLength(50)]
        public string SALA { get; set; }

        [StringLength(50)]
        public string FASE01 { get; set; }

        [StringLength(50)]
        public string FASE02 { get; set; }

        [StringLength(50)]
        public string FASE03 { get; set; }

        [StringLength(50)]
        public string FASE04 { get; set; }

        public int? LOCALPROVAID { get; set; }

        public int? SALAID { get; set; }

        [StringLength(50)]
        public string BAIXA { get; set; }

        public DateTime? CRIADO { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTALTERACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        public virtual EV_CLIENTE EV_CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_CONTROLENECESSIDADE> EV_CONTROLENECESSIDADE { get; set; }

        public virtual EV_EVENTO EV_EVENTO { get; set; }
    }
}
