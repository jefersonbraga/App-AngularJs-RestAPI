namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_PROVAQUESTOES
    {
        public int ID { get; set; }

        public int GRUPOQUESTOESID { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTATUALIZACAO { get; set; }

        public DateTime DTEXCLUSAO { get; set; }

        public virtual EV_GRUPODEQUESTOES EV_GRUPODEQUESTOES { get; set; }
    }
}
