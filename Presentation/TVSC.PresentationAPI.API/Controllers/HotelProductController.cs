using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TVSC.Domain.Entities.Santsg.Models;
using TVSC.Domain.Entities.Santsg.Models.Request;
using TVSC.Domain.Entities.Santsg.Models.Response;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelProductController : ControllerBase
    {
        IConfiguration _configuration;
        ILogger<HotelProductController> _logger;

        public HotelProductController(IConfiguration configuration, 
            ILogger<HotelProductController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("getarrivalautocomplete")]
        public async Task<IActionResult> GetArrivelAutoComplete(ArrivalAutoCompModel arrivalModel)
        {
            string postUrl = _configuration["TVServiceAdress"] + _configuration["Santsg:GetArrivalAutoComp"];

            var result = await ReturnResultAsync<ArrivalAutoCompModel>(postUrl, arrivalModel);

            //Json to model
            var model = JsonSerializer.Deserialize<ArrivalAutoCompleteResponseModel>(result);

            _logger.LogInformation($"Search Request. Query: '{arrivalModel.Query}'");
            return Ok(model.body.items);
        }

        [HttpPost("pricesearch")]
        public async Task<IActionResult> PriceSearch(PriceSearchRequestModel priceModel)
        {
            string postUrl = _configuration["TVServiceAdress"] + _configuration["Santsg:PriceSearch"];

            var result = await ReturnResultAsync<PriceSearchRequestModel>(postUrl, priceModel);


            return Ok(result);
        }

        private async Task<string> ReturnResultAsync<T>(string url, T model)
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

            //Request
            var response = await client.PostAsJsonAsync(url, model);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
