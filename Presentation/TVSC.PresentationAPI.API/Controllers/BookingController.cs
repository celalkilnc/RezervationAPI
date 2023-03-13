using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TVSC.Application;
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

            return Ok(responseModel);
        }


    }
}
