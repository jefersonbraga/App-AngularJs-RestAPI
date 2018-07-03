namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_ESCOLARIDADE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_ESCOLARIDADE()
        {
            EV_CLIENTE = new HashSet<EV_CLIENTE>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ESCOLARIDADE { get; set; }

        public int IDESCOLARIDADEANTIGO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_CLIENTE> EV_CLIENTE { get; set; }
    }
}
