using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.application.Usuarios.Responses
{
    public class SignUpResponse
    {
        public SignUpResponse(bool ok, string message)
        {
            Ok = ok;
            Message = message;
        }

        public bool Ok { get; set; }
        public string Message { get; set; }
    }
}
