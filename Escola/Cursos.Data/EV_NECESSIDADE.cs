namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_NECESSIDADE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_NECESSIDADE()
        {
            EV_CONTROLENECESSIDADE = new HashSet<EV_CONTROLENECESSIDADE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(250)]
        public string NECESSIDADE { get; set; }

        public int? TIPONECESSIDADEID { get; set; }

        public DateTime DTCADASTRO { get; set; }

        public DateTime DTATUALIZACAO { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_CONTROLENECESSIDADE> EV_CONTROLENECESSIDADE { get; set; }

        public virtual EV_TPNECESSIDADE EV_TPNECESSIDADE { get; set; }
    }
}
