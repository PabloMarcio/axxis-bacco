using axxis.bacco.api.Controllers.Base;
using axxis.bacco.application.Usuarios.Interfaces;
using axxis.bacco.application.Usuarios.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace axxis.bacco.api.Controllers.Usuarios
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<ActionResult> SignUp(SignUpRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return CustomResponse(ModelState);
            }

            var signupResult = await _usuarioService.SignUp(request);
            return Ok(signupResult);
        }
    }
}
