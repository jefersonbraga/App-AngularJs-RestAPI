namespace Cursos.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EV_CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EV_CLIENTE()
        {
            EV_AVALIACAOOBSERVACAO = new HashSet<EV_AVALIACAOOBSERVACAO>();
            EV_CONTROLENECESSIDADE = new HashSet<EV_CONTROLENECESSIDADE>();
            EV_INSCRICAO = new HashSet<EV_INSCRICAO>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string USERID { get; set; }

        [StringLength(250)]
        public string NOME { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string RG { get; set; }

        [StringLength(50)]
        public string ORGAOEMISSOR { get; set; }

        [StringLength(5)]
        public string UFEMISSOR { get; set; }

        public DateTime DTEMISSAO { get; set; }

        [StringLength(50)]
        public string CPF { get; set; }

        [StringLength(50)]
        public string NACIONALIDADE { get; set; }

        [StringLength(50)]
        public string NATURALIDADE { get; set; }

        public DateTime? DTNASCIMENTO { get; set; }

        [StringLength(50)]
        public string SEXO { get; set; }

        [StringLength(250)]
        public string NOMEPAI { get; set; }

        [StringLength(250)]
        public string NOMEMAE { get; set; }

        [StringLength(50)]
        public string CEP { get; set; }

        [StringLength(250)]
        public string ENDERECO { get; set; }

        [StringLength(250)]
        public string BAIRRO { get; set; }

        public int? NUMERO { get; set; }

        [StringLength(250)]
        public string COMPLEMENTO { get; set; }

        [StringLength(250)]
        public string CIDADE { get; set; }

        [StringLength(5)]
        public string ESTADO { get; set; }

        [StringLength(50)]
        public string TEL_RESIDENCIAL { get; set; }

        [StringLength(50)]
        public string TEL_COMERCIAL { get; set; }

        [StringLength(50)]
        public string TEL_CELULAR { get; set; }

        [StringLength(250)]
        public string SENHA { get; set; }

        [StringLength(10)]
        public string CAD_ADMINISTRACAO { get; set; }

        [StringLength(5)]
        public string ENVIO_SENHA { get; set; }

        public int? ORGAOTRABALHOID { get; set; }

        public int? ESCOLARIDADEID { get; set; }

        [StringLength(250)]
        public string INSTITUICAO { get; set; }

        public DateTime? DTCONCLUSAO { get; set; }

        public DateTime? DTCADASTRO { get; set; }

        public DateTime? DTALTERACAO { get; set; }

        public DateTime? DTULTIMOACESSO { get; set; }

        public long? IDANTIGO { get; set; }

        public int? IDORGAOANTIGO { get; set; }

        public int? IDESCOLARIDADEANTIGO { get; set; }

        public int? QTDACESSO { get; set; }

        public int? RECEBERFEEDS { get; set; }

        public DateTime? DTEXCLUSAO { get; set; }

        public virtual AD_ORGAOS AD_ORGAOS { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_AVALIACAOOBSERVACAO> EV_AVALIACAOOBSERVACAO { get; set; }

        public virtual EV_ESCOLARIDADE EV_ESCOLARIDADE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_CONTROLENECESSIDADE> EV_CONTROLENECESSIDADE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EV_INSCRICAO> EV_INSCRICAO { get; set; }
    }
}