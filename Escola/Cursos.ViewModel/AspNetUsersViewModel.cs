using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.ViewModel
{
    public partial class AspNetUsersViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime? Lockoutenddateutc { get; set; }
        public bool Lockoutenabled { get; set; }
        public int Accessfailedcount { get; set; }
        public string Username { get; set; }
    }
}
