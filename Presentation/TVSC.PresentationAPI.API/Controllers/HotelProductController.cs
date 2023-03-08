using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TVSC.Domain.Entities.Santsg.Models;
using TVSC.Domain.Entities.Santsg.Models.Response;

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

            //Tekrar eden kod!!!
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            var response = await client.PostAsJsonAsync(postUrl, arrivalModel);
            var result = await response.Content.ReadAsStringAsync();

            ArrivalAutoCompleteResponseModel model = JsonSerializer.Deserialize<ArrivalAutoCompleteResponseModel>(result);

            _logger.LogInformation($"Search Request. Query: '{arrivalModel.Query}'");
            return Ok(model.body.items);
        }
    }
}
