using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVSC.Application.Abstractions;

namespace TVSC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult GetUsers() 
        {
            var users = _userService.GetUsers();
            return Ok();
        }
        public IActionResult PostUser(int id) 
        {
            return Ok();
        }
    }
}
