using Microsoft.AspNetCore.Mvc;
using TVSC.Infrastructure.Santsg.Model;
using TVSC.Application.Service;
using Microsoft.Extensions.Caching.Memory;
using TVSC.Domain.Entities.Santsg.Models;
using TVSC.Application.Veriables; 

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        TokenModel tokenModel;

        ICacheService _cacheService;
        ILoginService _loginService;
        ILogger<LoginController> _logger;

        public LoginController(ILoginService loginService, ILogger<LoginController> logger, ICacheService cacheService)
        {
            _loginService = loginService;
            _logger = logger;
            _cacheService = cacheService;
        }

        [HttpPost("userlogin")]
        public async Task<IActionResult> PostTokenAsync(LoginModel login)
        {
            

            try
            {
                if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("Token")))
                {
                    tokenModel = await _loginService.PostTokenAsync(login);
                    HttpContext.Session.SetString("Token", tokenModel.token);
                }
                _logger.LogInformation(HttpContext.Session.GetString("Token"));
                _logger.LogInformation("Token request succesful.");
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Token request unsuccesful.  Exception: " + ex.Message);
            }
            return Ok(tokenModel);
        }

        [HttpPost("getarrivalautocomplete")]
        public IActionResult GetArrivalAutoComplete(ArrivalAutoCompModel model)
        {
            return Ok();
        }
    }
}
