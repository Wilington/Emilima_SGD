using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emilima_SGD.Models
{
    public class Usuario
    {
        public string CodUsua { get; set; }
        public string us_nombre { get; set; }
        public string us_mail { get; set; }
        public string us_contra { get; set; }
    }

    public class Login
    {
        public string us_usuario { get; set; }
        public string us_contra { get; set; }
    }
}
