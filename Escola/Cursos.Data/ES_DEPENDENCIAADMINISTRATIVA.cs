namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("escola.ES_DEPENDENCIAADMINISTRATIVA")]
    public partial class ES_DEPENDENCIAADMINISTRATIVA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ES_DEPENDENCIAADMINISTRATIVA()
        {
            ES_INSTITUICOES = new HashSet<ES_INSTITUICOES>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DESCRICAO { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTATUALIZACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ES_INSTITUICOES> ES_INSTITUICOES { get; set; }
    }
}
