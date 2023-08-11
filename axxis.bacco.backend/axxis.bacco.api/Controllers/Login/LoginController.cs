using axxis.bacco.api.Controllers.Base;
using axxis.bacco.application.Login.Interfaces;
using axxis.bacco.application.Login.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace axxis.bacco.api.Controllers.Login
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class LoginController : ApiController
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService; 
        }

        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticationRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return CustomResponse(ModelState);
            }

            var response = await _loginService.Authenticate(request);
            return Ok(response);
        }
    }
}
