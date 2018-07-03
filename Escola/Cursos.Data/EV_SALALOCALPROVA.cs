namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_SALALOCALPROVA
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string SALA { get; set; }

        public int? LOCALPROVAID { get; set; }

        public virtual EV_LOCALPROVA EV_LOCALPROVA { get; set; }
    }
}
