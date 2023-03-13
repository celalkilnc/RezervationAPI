using TVSC.Application;
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
            if (!ModelState.IsValid)
                throw new Exception();

            string postUrl = "productservice/getarrivalautocomplete";

             var result = await HttpHelper.ReturnResultAsync<ArrivalAutoCompModel>(
                                postUrl, arrivalModel, HttpContext.Session.GetString("Token"));
            //Json to model
            var model = JsonSerializer.Deserialize<ArrivalAutoCompleteResponseModel>(result);

            var filterModel = model.body.items
                                    .Where(x => x.country.name == arrivalModel.Country);
            _logger.LogInformation($"Search Request. Query: '{arrivalModel.Query}'");

            return Ok(filterModel);
        }

        [HttpPost("pricesearch")]
        public async Task<IActionResult> PriceSearch(PriceSearchRequestModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var defaultModel = new PriceSearchRequestModel()
            {
                // Defeault parameters 
                checkStopSale = true,
                checkAllotment = true,
                getOnlyBestOffers = true,
                getOnlyDiscountedPrice = true,

                // Client's parameters
                night = model.night,
                checkIn = model.checkIn,
                culture = model.culture,
                currency = model.currency,
                nationality = model.nationality,
                productType = model.productType,
                roomCriteria = model.roomCriteria,
                arrivalLocations = model.arrivalLocations
            };
            string postUrl ="productservice/pricesearch";

            var result = await HttpHelper.ReturnResultAsync<PriceSearchRequestModel>(
                                 postUrl, defaultModel, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<PriceSearchResponseModel>(result);

            HttpContext.Session.SetString("SearchId", responseModel.body.searchId.ToString());

            return Ok(responseModel);
        }

        [HttpPost("getproductinfo")]
        public async Task<IActionResult> GetProductInfo(ProductInfoRequestModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            HttpContext.Session.SetString("ProductId", model.product);
            string postUrl = "productservice/getproductInfo";

            var result = await HttpHelper.ReturnResultAsync<ProductInfoRequestModel>(
                                 postUrl, model, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<ProductInfoResponseModel>(result);

            return Ok(responseModel.body);
        }

        [HttpPost("getoffers")]
        public async Task<IActionResult> GetOffers(GetOffersRequestModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            model.searchId  = HttpContext.Session.GetString("SearchId");
            model.productId = HttpContext.Session.GetString("ProductId");

            string postUrl  ="productservice/getoffers";

            var result = await HttpHelper.ReturnResultAsync<GetOffersRequestModel>(
                                 postUrl, model, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<GetOffersResponseModel>(result);

            return Ok(responseModel);
        }

        [HttpPost("getofferdetails")]
        public async Task<IActionResult> GetOfferDetails(GetOfferDetailRequestModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            string postUrl =  "productservice/getofferdetails";

            var result = await HttpHelper.ReturnResultAsync<GetOfferDetailRequestModel>(
                                    postUrl, model, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<GetOfferDetailResponseModel>(result);

            return Ok(responseModel);
        }
    }
}
