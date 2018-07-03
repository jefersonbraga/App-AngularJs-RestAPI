namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AD_MENU
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string MENU { get; set; }

        public int ACOESID { get; set; }

        [StringLength(250)]
        public string LINK { get; set; }

        public int? ORDEM { get; set; }

        public bool? ATIVO { get; set; }

        public virtual AD_ACOES AD_ACOES { get; set; }
    }
}
