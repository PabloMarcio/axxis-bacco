using axxis.bacco.application.Usuarios.Interfaces;
using axxis.bacco.application.Usuarios.Requests;
using axxis.bacco.application.Usuarios.Responses;
using axxis.bacco.backend.infra.extensions;
using axxis.bacco.domain.Usuarios;
using axxis.bacco.domain.Usuarios.Enums;
using axxis.bacco.domain.Usuarios.Repositories;
using System.Text;

namespace axxis.bacco.application.Usuarios.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public RolesListResponse GetRolesList()
        {
            var tiposUsuario = (TipoUsuario[])Enum.GetValues(typeof(TipoUsuario));
            var result = new RolesListResponse();
            foreach (var tipo in tiposUsuario)
            {
                var role = new Role
                {
                    Name = tipo.ToString(),
                    Id = (int)tipo
                };

                result.Roles.Add(role);
            }
            return result;
        }

        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            var validationErrors = new StringBuilder();
            if (request.Email.IsNotValidEmail()) 
            {
                validationErrors.AppendLine("- Endereço de e-mail inválido;");
            }
            
            if (DateTime.TryParse(request.Birthday, out DateTime birthday) == false)
            {
                validationErrors.AppendLine("- A data de nascimento informada é inválida;");
            }
            var usuario = (await _usuarioRepository.CreateQuery().FilterByEmail(request.Email).ToListASync()).FirstOrDefault();
            if (usuario != null)
            {
                validationErrors.AppendLine("- Endereço de e-mail já está sendo utilizado;");                
            }
            if (request.Password != request.PasswordConfirmation)
            {
                validationErrors.AppendLine("- A confirmação de senha é diferente da senha informada;");
            }
            if (validationErrors.Length > 0)
            {
                return new SignUpResponse(false, $"Ocorreram os seguintes erros: /r/n {validationErrors}");
            }
            var novoUsuario = new Usuario
            {
                Id = _usuarioRepository.NewId(),
                TipoUsuario = TipoUsuario.Cliente,
                Cpf = request.Cpf,
                DataNascimento = birthday,
                Email = request.Email,
                Endereco = request.Address,
                Senha = request.Password.ToBase64().SHA256(),
                Telefone = request.Telephone,
                Nome = request.Name
            };

            _usuarioRepository.Add(novoUsuario);
            return new SignUpResponse(true, "O cadastro foi realizado");
        }
    }
}
