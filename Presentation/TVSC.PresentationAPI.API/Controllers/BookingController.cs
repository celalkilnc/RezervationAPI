using System.Text.Json;
using TVSC.Application;
using Microsoft.AspNetCore.Mvc;
using TVSC.Domain.Entities.Santsg.Models.Request;
using TVSC.Domain.Entities.Santsg.Models.Response;

namespace TVSC.PresentationAPI.API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpPost("begintransaction")]
        public async Task<IActionResult> BeginTransaction(BeginTransactionRequestModel model)
        {
            if(!ModelState.IsValid)
                throw new Exception();

            var result = await HttpHelper.ReturnResultAsync<BeginTransactionRequestModel>(
                "bookingservice/begintransaction", model, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<BeginTransactionResponseModel>(result);

            HttpContext.Session.SetString("TransactionId",responseModel.body.transactionId);

            return Ok(responseModel);
        }

        [HttpPost("setrezervationinfo")]
        public async Task<IActionResult> SetRezervationInfo(SetRezervationInfoRequestModel model)
        {
            model.transactionId = HttpContext.Session.GetString("TransactionId");

            if (!ModelState.IsValid)
                throw new Exception();

            var result = await HttpHelper.ReturnResultAsync<SetRezervationInfoRequestModel>(
                "bookingservice/setreservationinfo", model, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<SetRezervationInfoResponseModel>(result);

            return Ok(responseModel);
        }
    }
}
