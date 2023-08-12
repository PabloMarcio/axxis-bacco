using axxis.bacco.domain.Usuarios.Enums;
using Microsoft.AspNetCore.Authorization;

namespace axxis.bacco.api.Policies
{
    public class TipoUsuarioRequirement : IAuthorizationRequirement
    {
        public TipoUsuario TipoUsuario { get; }

        public TipoUsuarioRequirement(int nivelAcesso)
        {
            TipoUsuario = (TipoUsuario)nivelAcesso;
        }

        public TipoUsuarioRequirement(TipoUsuario tipoUsuario)
        {
            TipoUsuario = tipoUsuario;
        }
    }

    public class TipoUsuarioHandler : AuthorizationHandler<TipoUsuarioRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, TipoUsuarioRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "TipoUsuario"))
            {
                return Task.CompletedTask;
            }

            var tipoUsuario = (TipoUsuario)Enum.Parse(
                typeof(TipoUsuario), context.User.FindFirst("TipoUsuario").Value);

            if ((int)tipoUsuario >= (int)requirement.TipoUsuario)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
