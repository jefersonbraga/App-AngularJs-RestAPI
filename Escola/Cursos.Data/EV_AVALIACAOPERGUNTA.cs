namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_AVALIACAOPERGUNTA
    {
        public int ID { get; set; }

        public int AVALIACAOID { get; set; }

        [Required]
        [StringLength(100)]
        public string TITULO { get; set; }

        public int ORDEM { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTATUALIZACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }
    }
}
