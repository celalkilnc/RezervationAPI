using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TVSC.Application;
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

            var result = await HttpHelper.ReturnResultAsync<ArrivalAutoCompModel>(
                            postUrl, arrivalModel, HttpContext.Session.GetString("Token"));

            //Json to model
            var model = JsonSerializer.Deserialize<ArrivalAutoCompleteResponseModel>(result);

            _logger.LogInformation($"Search Request. Query: '{arrivalModel.Query}'");
            return Ok(model.body.items);
        }

        [HttpPost("pricesearch")]
        public async Task<IActionResult> PriceSearch(PriceSearchRequestModel priceModel)
        {
            string postUrl = _configuration["TVServiceAdress"] + _configuration["Santsg:PriceSearch"];

            var result = await HttpHelper.ReturnResultAsync<PriceSearchRequestModel>(
                            postUrl, priceModel, HttpContext.Session.GetString("Token"));

           var responseModel = JsonSerializer.Deserialize<PriceSearchResponseModel>(result);

            return Ok(responseModel.body);
        }

        [HttpPost("getproductinfo")]
        public async Task<IActionResult> GetProductInfo(ProductInfoRequestModel model)
        {
            string postUrl = _configuration["TVServiceAdress"] + _configuration["Santsg:GetProductInfo"];

            var result = await HttpHelper.ReturnResultAsync<ProductInfoRequestModel>(
                            postUrl, model, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<ProductInfoResponseModel>(result);

            return Ok(responseModel);
        }
    }
}
