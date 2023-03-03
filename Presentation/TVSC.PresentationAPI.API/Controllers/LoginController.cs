using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System.Text.Json.Nodes;
using System.Text;
using TVSC.Infrastructure.Santsg.Model;
using System.Net.Http;
using TVSC.Infrastructure.Santsg;
using RestSharp;
using Nancy;
using RestClient = RestSharp.RestClient;
using System.Security.Policy;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly string _serviceAdress = "https://preprod-services.tourvisio.com/v2";

        public LoginController()
        {

        }

        [HttpPost("userlogin")]
        public async Task<IActionResult> UserLoginAsync(LoginModel login)
        {
            string postUrl = _serviceAdress + "/api/authenticationservice/login";
            var json = new JavaScriptSerializer().Serialize(login);
            HttpClient client = new HttpClient();

            //var content  = new StringContent(lo, Encoding.UTF8, "application/json");

            var response = await client.PostAsJsonAsync(postUrl, login);
            var id = await response.Content.ReadAsStringAsync(); 
            // Response içindeki veriyi okumak için ekstra metod gereklidir

            return Ok(id);
        }
    }
}
