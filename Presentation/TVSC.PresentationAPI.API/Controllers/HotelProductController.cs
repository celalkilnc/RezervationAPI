using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using TVSC.Application;
using TVSC.Domain.Entities.Santsg.Models;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelProductController : ControllerBase
    {
        //HttpClient client;
        IConfiguration _configuration;
        ILogger<HotelProductController> _logger;
        public HotelProductController(IConfiguration configuration, ILogger<HotelProductController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("getarrivalautocomplete")]
        public async Task<IActionResult> GetArrivelAutoComplete(ArrivalAutoCompModel arrivalModel)
        {
            HttpClient client = new();
            string postUrl = _configuration["TVServiceAdress"] + _configuration["Santsg:GetArrivalAutoComp"];
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            //client = HttpHelper.HttpClientReturn(HttpContext.Session.GetString("Token"));

            var response = await client.PostAsJsonAsync(postUrl, arrivalModel);
            var result = await response.Content.ReadAsStringAsync();

            return Ok(result);
        }
    }
}
