using System.Text.Json;
using TVSC.Application;
using Microsoft.AspNetCore.Mvc;
using TVSC.Domain.Entities.Santsg.Models.Request;
using TVSC.Domain.Entities.Santsg.Models.Response;
using TVSC.Application.Service;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IMailService _mailService;
        public BookingController(IMailService mailService)
        {
            _mailService = mailService;
        }


        [HttpPost("begintransaction")]
        public async Task<IActionResult> BeginTransaction(BeginTransactionRequestModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var result = await HttpHelper.ReturnResultAsync<BeginTransactionRequestModel>(
                "bookingservice/begintransaction", model, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<BeginTransactionResponseModel>(result);

            HttpContext.Session.SetString("TransactionId", responseModel.body.transactionId);

            return Ok(responseModel);
        }

        [HttpPost("setrezervationinfo")]
        public async Task<IActionResult> SetRezervationInfo(SetRezervationInfoRequestModel model)
        {
            HttpContext.Session.SetString("CustomerEmail", model.customerInfo.address.email);

            model.transactionId = HttpContext.Session.GetString("TransactionId");

            if (!ModelState.IsValid)
                throw new Exception();

            var result = await HttpHelper.ReturnResultAsync<SetRezervationInfoRequestModel>(
                "bookingservice/setreservationinfo", model, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<SetRezervationInfoResponseModel>(result);

            return Ok(responseModel);
        }

        [HttpPost("committransaction")]
        public async Task<IActionResult> CommitTransaction(CommitTransactionRequestModel model)
        {
            model.transactionId = HttpContext.Session.GetString("TransactionId");

            if (!ModelState.IsValid)
                throw new Exception();

            var result = await HttpHelper.ReturnResultAsync<CommitTransactionRequestModel>(
                "bookingservice/committransaction", model, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<CommitTransactionResponseModel>(result);

            await _mailService.SendMailAsync(HttpContext.Session.GetString(
                "CustomerEmail"), "Rezervation Succesful", $"Rezervation number: <strong>{responseModel.body.reservationNumber}</strong>");

            return Ok(responseModel);
        }

        [HttpPost("getreservationdetail")]
        public async Task<IActionResult> GetReservationDetail(GetREzervationDetailRequestModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var result = await HttpHelper.ReturnResultAsync<GetREzervationDetailRequestModel>(
                "bookingservice/getreservationdetail", model, HttpContext.Session.GetString("Token"));

            var responseModel = JsonSerializer.Deserialize<GetRezervationDetailResponseModel>(result);

            return Ok(responseModel);
        }
    }
}
