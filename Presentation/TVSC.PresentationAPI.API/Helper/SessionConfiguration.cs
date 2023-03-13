using Microsoft.AspNetCore.Mvc;

namespace TVSC.PresentationAPI.API.Helper
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionConfiguration : ControllerBase
    {
        public string Token
        {
            get {  return HttpContext.Session.GetString("Token"); }
        }

        public string SearchId
        {
            get { return HttpContext.Session.GetString("SearchId");}
        }

        public string ProductId
        {
            get { return HttpContext.Session.GetString("ProductId");}
        }
    }
}
