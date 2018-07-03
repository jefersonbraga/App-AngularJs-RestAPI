namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("escola.ES_LISTAATIVIDADES")]
    public partial class ES_LISTAATIVIDADES
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string USUARIOID { get; set; }

        [Required]
        [StringLength(250)]
        public string DESCRICAO { get; set; }

        public bool STATUS { get; set; }

        public DateTime DT_CRIACAO { get; set; }

        public DateTime DT_ATUALIZACAO { get; set; }

        public DateTime? DT_EXCLUSAO { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }
    }
}