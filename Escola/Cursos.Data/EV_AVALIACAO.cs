namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_AVALIACAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_AVALIACAO()
        {
            EV_AVALIACAOOBSERVACAO = new HashSet<EV_AVALIACAOOBSERVACAO>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string TITULO { get; set; }

        public string DESCRICAO { get; set; }

        public int EVENTOID { get; set; }

        [StringLength(5)]
        public string DISPONIVEL { get; set; }

        public DateTime? DTINICIO { get; set; }

        public TimeSpan? HORAINICIO { get; set; }

        public DateTime? DTTERMINO { get; set; }

        public TimeSpan? HORATERMINO { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTALTERACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        public virtual EV_EVENTO EV_EVENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_AVALIACAOOBSERVACAO> EV_AVALIACAOOBSERVACAO { get; set; }
    }
}
