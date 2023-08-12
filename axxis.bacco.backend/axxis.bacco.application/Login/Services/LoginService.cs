using axxis.bacco.application.Login.Interfaces;
using axxis.bacco.application.Login.Requests;
using axxis.bacco.application.Login.Responses;
using axxis.bacco.domain.Usuarios.Repositories;
using axxis.bacco.backend.infra.extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using axxis.bacco.domain.Login;
using axxis.bacco.domain.Usuarios;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using axxis.bacco.domain.Usuarios.Enums;

namespace axxis.bacco.application.Login.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            if (CheckForDefaultAdministratorLogin(request))
            {
                var defaultAdministratorLoginInfo = new LoginInfo();
                defaultAdministratorLoginInfo.Id = 0;
                defaultAdministratorLoginInfo.Name = "Administrador";
                defaultAdministratorLoginInfo.Notifications = "";
                defaultAdministratorLoginInfo.Role = TipoUsuario.Administrador;
                defaultAdministratorLoginInfo.Token = GenerateJwtToken(new Usuario() { Email = "Admin", TipoUsuario = domain.Usuarios.Enums.TipoUsuario.Administrador });
                return new AuthenticationResponse(true, "Login realizado", defaultAdministratorLoginInfo);
            }
            var usuario = (await _usuarioRepository.CreateQuery().FilterByEmail(request.Username).ToListASync()).FirstOrDefault();
            if (usuario == null)
            {
                return new AuthenticationResponse(false, "Usuário e senha errados", null);
            }
            if (usuario.Email.IsNotValidEmail())
            {
                return new AuthenticationResponse(false, "Usuário e senha errados", null);
            }

            var senha = request.Password.ToBase64().SHA256();
            if (usuario.Senha.Equals(senha) == false)
            {
                return new AuthenticationResponse(false, "Usuário e senha errados", null);
            }

            var loginInfo = new LoginInfo
            {
                Id = usuario.Id,
                Name = usuario.Nome,
                Notifications = CheckNotifications(), //To Do
                Role = usuario.TipoUsuario,
                Token = GenerateJwtToken(usuario)
            };

            return new AuthenticationResponse(true, "Login realizado", loginInfo);
        }

        private bool CheckForDefaultAdministratorLogin(AuthenticationRequest request)
        {
            if ((request.Username.ToLower() != "admin") && (request.Password.ToLower() != "admin")) 
                return false;

            // caso o sistema não tenha um usuário administrador valida o login com admin/admin. Caso tenha pelo menos um usuário cadastrado como administrador, este login perde a validade
            var usuario = _usuarioRepository.CreateQuery().FilterByRole(TipoUsuario.Administrador).ToListASync().Result;
            if (usuario.Any())
            {
                return false;
            }
            return true;
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Yzk0Y2Q4MGUtOWM3OC00YmI3LTk2M2ItZTRjZGJjNGIxOTAy"); //  TODO: passar para env
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", usuario.Email), new Claim("tipoUsuario", usuario.TipoUsuario.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = "AXXIS",
                Audience = "BACCO",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string CheckNotifications()
        {
            return ""; // implementar notificações
        }
    }
}
