namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_GRUPODEQUESTOES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_GRUPODEQUESTOES()
        {
            EV_PROVAQUESTOES = new HashSet<EV_PROVAQUESTOES>();
            EV_QUESTOESCORRECAO = new HashSet<EV_QUESTOESCORRECAO>();
        }

        public int ID { get; set; }

        public int RECURSOID { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTATUALIZACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        public virtual EV_RECURSOPROVA EV_RECURSOPROVA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_PROVAQUESTOES> EV_PROVAQUESTOES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_QUESTOESCORRECAO> EV_QUESTOESCORRECAO { get; set; }
    }
}
