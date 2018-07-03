namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_CONTROLENECESSIDADE
    {
        public int ID { get; set; }

        public int? INCRICAOID { get; set; }

        public int? CLIENTEID { get; set; }

        public int? NECESSIDADEID { get; set; }

        public virtual EV_CLIENTE EV_CLIENTE { get; set; }

        public virtual EV_INSCRICAO EV_INSCRICAO { get; set; }

        public virtual EV_NECESSIDADE EV_NECESSIDADE { get; set; }
    }
}
