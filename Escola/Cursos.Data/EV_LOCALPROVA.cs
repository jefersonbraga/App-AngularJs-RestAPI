namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_LOCALPROVA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_LOCALPROVA()
        {
            EV_SALALOCALPROVA = new HashSet<EV_SALALOCALPROVA>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string LOCAL { get; set; }

        [Required]
        [StringLength(50)]
        public string CEP { get; set; }

        [Required]
        [StringLength(250)]
        public string LOGRADOURO { get; set; }

        [Required]
        [StringLength(250)]
        public string ENDERECO { get; set; }

        [Required]
        [StringLength(250)]
        public string BAIRRO { get; set; }

        [StringLength(250)]
        public string COMPLEMENTO { get; set; }

        public int? NUMERO { get; set; }

        [Required]
        [StringLength(250)]
        public string CIDADE { get; set; }

        [Required]
        [StringLength(2)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_SALALOCALPROVA> EV_SALALOCALPROVA { get; set; }
    }
}
