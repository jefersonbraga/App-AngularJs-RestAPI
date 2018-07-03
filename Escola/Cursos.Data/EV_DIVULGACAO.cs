namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_DIVULGACAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_DIVULGACAO()
        {
            EV_DIVULGACAOENVIOS = new HashSet<EV_DIVULGACAOENVIOS>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string TITULO { get; set; }

        [Required]
        public string MENSAGEM { get; set; }

        public DateTime DTCRIACAO { get; set; }

        public DateTime DTALTERACAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_DIVULGACAOENVIOS> EV_DIVULGACAOENVIOS { get; set; }
    }
}
