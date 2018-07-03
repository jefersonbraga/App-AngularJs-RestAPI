namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adm.AD_ORGAOEMISSOR")]
    public partial class AD_ORGAOEMISSOR
    {
        [Key]
        [StringLength(50)]
        public string CO_EMISSOR { get; set; }

        [Required]
        [StringLength(70)]
        public string NO_EMISSOR { get; set; }
    }
}
