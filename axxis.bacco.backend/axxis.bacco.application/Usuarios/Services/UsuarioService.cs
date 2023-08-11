using axxis.bacco.application.Usuarios.Interfaces;
using axxis.bacco.application.Usuarios.Requests;
using axxis.bacco.application.Usuarios.Responses;
using axxis.bacco.backend.infra.extensions;
using axxis.bacco.domain.Usuarios;
using axxis.bacco.domain.Usuarios.Enums;
using axxis.bacco.domain.Usuarios.Repositories;

namespace axxis.bacco.application.Usuarios.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            if (request.Email.IsNotValidEmail()) 
            {
                return new SignUpResponse(false, "Endereço de e-mail inválido");
            }
            var usuario = (await _usuarioRepository.CreateQuery().FilterByEmail(request.Email).ToListASync()).FirstOrDefault();
            if (usuario != null)
            {
                return new SignUpResponse(false, "Endereço de e-mail já está sendo utilizado");
            }
            if (request.Password != request.PasswordConfirmation)
            {
                return new SignUpResponse(false, "A confirmação de senha é diferente da senha informada");
            }

            var novoUsuario = new Usuario
            {
                Id = _usuarioRepository.NewId(),
                TipoUsuario = TipoUsuario.Cliente,
                Cpf = request.Cpf,
                DataNascimento = request.Birthday,
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
