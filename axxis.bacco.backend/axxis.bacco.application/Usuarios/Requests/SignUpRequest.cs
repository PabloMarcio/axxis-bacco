using axxis.bacco.domain.Usuarios.Enums;
using System.ComponentModel.DataAnnotations;

namespace axxis.bacco.application.Usuarios.Requests
{
    public class SignUpRequest
    {
        [Required(ErrorMessage = "Informe o seu nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o sua data de nascimento")]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "Informe o seu e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Defina uma senha para acessar o Bacco")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme a sua senha para acessar o Bacco")]
        public string PasswordConfirmation { get; set; }

        public string Cpf { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }        
    }
}
