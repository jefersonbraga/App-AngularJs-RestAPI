namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_TIPOEVENTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DESCRICAO { get; set; }

        public DateTime DTALTERACAO { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }
    }
}
