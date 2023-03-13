using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVSC.Application;
using TVSC.Domain.Entities.Santsg.Models.Request;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpPost("begintransaction")]
        public async Task<IActionResult> BeginTransaction(BeginTransactionRequestModel model)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            var result = await HttpHelper.ReturnResultAsync<BeginTransactionRequestModel>(
                "api/bookingservice/begintransaction", model, HttpContext.Session.GetString("Token"));

            return Ok(result);
        }
    }
}
