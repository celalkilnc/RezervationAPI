using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVSC.Infrastructure.Santsg.Model;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        HttpClient client;

        private readonly string _serviceAdress = "https://preprod-services.tourvisio.com/v2";
        public LoginController()
        {
            client= new HttpClient();
        }

        [HttpPost("userlogin")]
        public async Task<IActionResult> UserLoginAsync(LoginModel login )
        {
            HttpResponseMessage response = await client.GetAsync( _serviceAdress + "/api/authenticationservice/login");
            return Ok(response);
        }
    }
}
