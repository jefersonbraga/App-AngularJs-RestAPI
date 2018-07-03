namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AD_REFRESHTOKEN
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string USERID { get; set; }

        [Required]
        [StringLength(50)]
        public string HASH { get; set; }

        [Required]
        public string PROTECTEDTICKET { get; set; }

        public DateTime DTEMISSAO { get; set; }

        public DateTime DTEMISSAOUTC { get; set; }

        public DateTime DTEXPIRACAO { get; set; }

        public DateTime DTEXPIRACAOUTC { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }
    }
}