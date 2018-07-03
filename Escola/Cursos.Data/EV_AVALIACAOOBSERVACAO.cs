namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_AVALIACAOOBSERVACAO
    {
        public int ID { get; set; }

        public int AVALIACAOID { get; set; }

        public int CLIENTEID { get; set; }

        [Required]
        public string OBSERVACAO { get; set; }

        public DateTime DTATUALIZACAO { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        public virtual EV_AVALIACAO EV_AVALIACAO { get; set; }

        public virtual EV_CLIENTE EV_CLIENTE { get; set; }
    }
}
