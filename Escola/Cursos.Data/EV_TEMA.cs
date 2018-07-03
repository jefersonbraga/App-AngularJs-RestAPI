namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_TEMA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_TEMA()
        {
            EV_EVENTO = new HashSet<EV_EVENTO>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string TEMA { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTATUALIZACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_EVENTO> EV_EVENTO { get; set; }
    }
}
