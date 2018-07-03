namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AD_ACOES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AD_ACOES()
        {
            AD_MENU = new HashSet<AD_MENU>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string ACOES { get; set; }

        public int MODULOID { get; set; }

        [StringLength(250)]
        public string LINK { get; set; }

        [StringLength(50)]
        public string ICONE { get; set; }

        public int? ORDEM { get; set; }

        public virtual AD_MODULOS AD_MODULOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AD_MENU> AD_MENU { get; set; }
    }
}
