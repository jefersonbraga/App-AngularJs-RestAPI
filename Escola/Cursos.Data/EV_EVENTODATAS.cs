namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_EVENTODATAS
    {
        public int ID { get; set; }

        public int IDEVENTO { get; set; }

        public DateTime DTINICIO { get; set; }

        public DateTime DTTERMINO { get; set; }

        public TimeSpan HORAINICIO { get; set; }

        public TimeSpan HORATERMINO { get; set; }

        public virtual EV_EVENTO EV_EVENTO { get; set; }
    }
}
