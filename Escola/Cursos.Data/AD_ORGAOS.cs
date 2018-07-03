namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AD_ORGAOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AD_ORGAOS()
        {
            EV_CLIENTE = new HashSet<EV_CLIENTE>();
            EV_DIVULGACAOENVIOS = new HashSet<EV_DIVULGACAOENVIOS>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string ORGAO { get; set; }

        public int? IDORGAOANTIGO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_CLIENTE> EV_CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_DIVULGACAOENVIOS> EV_DIVULGACAOENVIOS { get; set; }
    }
}
