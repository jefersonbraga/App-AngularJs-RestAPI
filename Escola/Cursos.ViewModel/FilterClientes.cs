using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.ViewModel
{
    public class FilterClientes
    {
        //{"Cpf":"cpf","Nome":"VINÍCIUS DA SILVA PEREIRA","Email":"email","Rg":"rg","Sexo":"sexo","Estado":"estado","Telcelular":"tel","Instituicao":"istitu","Cidade":"cida"}
        public string Cpf { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
        public string Sexo { get; set; }
        public string Estado { get; set; }
        public string Telcelular { get; set; }
        public string Instituicao { get; set; }
        public string Cidade { get; set; }
        public int? Eventoid { get; set; }
        public int? Orgaotrabalhoid { get; set; }
        public string Letra { get; set; }
        public DateTime? Dtaniversario { get; set; }
        public string Columnsreport { get; set; }
    }
}