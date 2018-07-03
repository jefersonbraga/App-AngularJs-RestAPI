using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cursos.Api.Models
{
    public class AuthenticationIdentity : System.Security.Principal.GenericIdentity
    {
        public AuthenticationIdentity(string name) : base(name)
        {

        }
    }
}