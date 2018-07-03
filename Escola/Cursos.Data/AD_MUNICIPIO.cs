namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adm.AD_MUNICIPIO")]
    public partial class AD_MUNICIPIO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NU_MUNICIPIO { get; set; }

        [Required]
        [StringLength(50)]
        public string NO_MUNICIPIO { get; set; }

        [Required]
        [StringLength(3)]
        public string SG_UF { get; set; }

        [StringLength(3)]
        public string CO_DDD { get; set; }
    }
}
