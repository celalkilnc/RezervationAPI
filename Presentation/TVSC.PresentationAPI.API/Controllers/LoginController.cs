using Microsoft.AspNetCore.Mvc;
using TVSC.Infrastructure.Santsg.Model;
using TVSC.Application.Service;
using Microsoft.Extensions.Caching.Memory;
using TVSC.Domain.Entities.Santsg.Models;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IMemoryCache _memoryCache;
        ILoginService _loginService;
        TokenModel tokenModel;
        ILogger<LoginController> _logger;

        public LoginController(ILoginService loginService, IMemoryCache memoryCache, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        [HttpPost("userlogin")]
        public async Task<IActionResult> PostTokenAsync(LoginModel login)
        {
            tokenModel = await _loginService.PostTokenAsync(login);
            //if (!_memoryCache.TryGetValue("Token", tokenModel))
            //{
                
            //    var cacheOptions = new MemoryCacheEntryOptions()
            //        .SetSlidingExpiration(TimeSpan.FromMinutes(15))
            //        .SetPriority(CacheItemPriority.Normal);
            //}

            _logger.LogInformation("Token request succesful.");
            return Ok(tokenModel);
        }

        [HttpPost("getarrivalautocomplete")]
        public IActionResult GetArrivalAutoComplete(ArrivalAutoCompModel model)
        { 
            
            return Ok();
        }
    }
}
