using Microsoft.AspNetCore.Mvc;
using TVSC.Infrastructure.Santsg.Model;
using TVSC.Application.Service;
using Microsoft.Extensions.Caching.Memory;
using TVSC.Domain.Entities.Santsg.Models;
using TVSC.Application.Veriables;
using System.Text.Json;
using TVSC.Application;
using TVSC.Domain.Entities.Santsg.Models.Response;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        HttpClient client;
        #region Dependency Injection
        ICacheService _cacheService;
        ILogger<LoginController> _logger;
        IConfiguration _configuration;

        public LoginController(
            ILogger<LoginController> logger,
            ICacheService cacheService, 
            IConfiguration configuration)
        {
            _logger = logger;
            _cacheService = cacheService;
            _configuration = configuration;
            client = new();
        }
        #endregion

        [HttpPost("userlogin")]
        public async Task<IActionResult> LoginAsync(LoginModel login)
        {
            string postUrl = _configuration["TVServiceAdress"] + "authenticationservice/login";
            LoginResponseModel responseModel = new();

            try
            {
                if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("Token")))
                {
                    var response = await client.PostAsJsonAsync(postUrl, login);
                    var result = await response.Content.ReadAsStringAsync();
                    responseModel = JsonSerializer.Deserialize<LoginResponseModel>(result);

                    if (responseModel.body == null)
                        throw new Exception("Error: 'Body' is null!..");

                    HttpContext.Session.SetString("Token", responseModel.body.token);
                }
                _logger.LogInformation("Token request succesful.", responseModel);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Token request unsuccesful.  Exception: " + ex.Message);
            }
            return Ok(HttpContext.Session.GetString("Token"));
        }
    }
}
