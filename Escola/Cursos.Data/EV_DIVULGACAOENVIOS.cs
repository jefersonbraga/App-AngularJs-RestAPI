namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_DIVULGACAOENVIOS
    {
        public int ID { get; set; }

        public int IDDIVULGACAO { get; set; }

        public int? IDEVENTO { get; set; }

        public int? IDORGAOTRABALHO { get; set; }

        [StringLength(1)]
        public string DSLETRAALFABETO { get; set; }

        [StringLength(50)]
        public string EMAILTESTE { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAILREMETENTE { get; set; }

        [StringLength(50)]
        public string ASSUNTO { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTALTERACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        public virtual AD_ORGAOS AD_ORGAOS { get; set; }

        public virtual EV_DIVULGACAO EV_DIVULGACAO { get; set; }

        public virtual EV_EVENTO EV_EVENTO { get; set; }
    }
}
