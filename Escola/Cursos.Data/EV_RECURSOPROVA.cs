namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_RECURSOPROVA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_RECURSOPROVA()
        {
            EV_GRUPODEQUESTOES = new HashSet<EV_GRUPODEQUESTOES>();
        }

        public int ID { get; set; }

        public int EVENTOID { get; set; }

        [Required]
        [StringLength(100)]
        public string TITULO { get; set; }

        public string INSTRUCOES { get; set; }

        public DateTime DTINICIO { get; set; }

        public TimeSpan? HRINICIO { get; set; }

        public DateTime DTTERMINO { get; set; }

        public TimeSpan? HRTERMINO { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTATUALIZACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        public virtual EV_EVENTO EV_EVENTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_GRUPODEQUESTOES> EV_GRUPODEQUESTOES { get; set; }
    }
}
