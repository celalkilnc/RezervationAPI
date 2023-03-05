using Microsoft.AspNetCore.Mvc;
using TVSC.Infrastructure.Santsg.Model;
using TVSC.Application.Service;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("userlogin")]
        public async Task<IActionResult> PostTokenAsync(LoginModel login)
        {
            var tokenModel = await _loginService.PostTokenAsync(login);

            return Ok(tokenModel);
        }
    }
}
