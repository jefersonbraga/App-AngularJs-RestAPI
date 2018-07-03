using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cursos.Api.Models
{
    public class AutenticationModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string grant_type { get; set; }
        public string client_id { get; set; }
    }
}