namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adm.AD_UF")]
    public partial class AD_UF
    {
        [Key]
        [StringLength(2)]
        public string SG_UF { get; set; }

        [Required]
        [StringLength(20)]
        public string NO_UF { get; set; }

        [StringLength(20)]
        public string NO_REGIAO { get; set; }

        [StringLength(20)]
        public string NO_PAIS { get; set; }
    }
}
