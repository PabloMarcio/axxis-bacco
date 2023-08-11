using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace axxis.bacco.application.Login.Requests
{
    public class AuthenticationRequest
    {
        [Required(ErrorMessage = "Informe o e-mail")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
    }
}
