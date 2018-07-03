namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("escola.ES_INSTITUICOES")]
    public partial class ES_INSTITUICOES
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int DPADMID { get; set; }

        [Required]
        [StringLength(200)]
        public string NOME { get; set; }

        [Required]
        [StringLength(10)]
        public string SIGLA { get; set; }

        [Required]
        [StringLength(2)]
        public string UF { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTATUALIZACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        public virtual ES_DEPENDENCIAADMINISTRATIVA ES_DEPENDENCIAADMINISTRATIVA { get; set; }
    }
}
