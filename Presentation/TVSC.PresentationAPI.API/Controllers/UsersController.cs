using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using TVSC.Application.Repositories;
using TVSC.Application.Service;
using TVSC.Domain.Entities;
using TVSC.Domain.Enumerations;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Dependency Injection 
        readonly private IUserWriteRepository _userWriteRepository;
        readonly private IUserReadRepository _userReadRepository;
        readonly private IMailService _mailService;
        readonly private ILogger<UsersController> _logger;
        readonly ICacheService _cacheService;

        public UsersController(
            IUserWriteRepository userWriteRepository,
            IUserReadRepository userReadRepository,
            IMailService mailService,
            ILogger<UsersController> logger,
            ICacheService cacheService)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _mailService = mailService;
            _logger = logger;
            _cacheService = cacheService;
        }
        #endregion

        [HttpGet("GetUsers")]
        public IQueryable<User> GetUsers()
        {
            //Kullanıcıları db'den çekip deleted olmayanları döner   
            var users = _userReadRepository.GetAll();

            _logger.LogInformation(
                $"Request succesful: 'Get Users'");

            _logger.LogInformation(HttpContext.Session.GetString("Token"));

            return users.Where(x => x.Status != StatusEnum.Deleted);
        }

        [HttpGet("getdeletedusers")]
        public IQueryable<User> GetDeletedUsers()
        {
            //Kullanıcıları db'den çekip deleted olmayanları döner       
            var users = _userReadRepository.GetAll();

            _logger.LogInformation($"Request succesful. 'GetDeleteUsers'");
            return users.Where(x => x.Status == StatusEnum.Deleted);

        }

        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser(User user)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            user.CreatedDate = DateTime.Now;
            await _userWriteRepository.AddAsync(user);
            await _mailService.SendMailAsync(user.Email, subject: "User Record",
                $"<strong>{user.Username}</strong> record sucesful.Welcome.");
            await _userWriteRepository.SaveAsync();
            
            _logger.LogInformation($"Request succesful. Added user: {user.Username} - {user.Id}");

            return Ok($"{user.Username} successfully added.");
        }

        [HttpGet("changestatus")]
        public async Task ChangeStatus(User user)
        {
            User _user = await _userReadRepository.GetByIdAsync(user.Id.ToString());

            if (_user.Status == StatusEnum.Deleted || !ModelState.IsValid)
                throw new Exception();

            StatusEnum state;
            if (_user.Status == StatusEnum.Active)
                state = StatusEnum.Passive;
            else
                state = StatusEnum.Active; 

            _user.Status = state;
            await _userWriteRepository.SaveAsync();
        }

        [HttpGet("updateuser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            if (!ModelState.IsValid || user.Status == StatusEnum.Deleted)
                throw new Exception();

            //id yoluyla verileri değişmesi gereken kullanıcıyı çekme
            User useredit = await _userReadRepository.GetByIdAsync(user.Id.ToString());

            user.CreatedDate = useredit.CreatedDate;
            user.Status      = useredit.Status;
            useredit = user;

            await _userWriteRepository.SaveAsync();
            return Ok($"'{useredit.Username}' updated");
        }

        [HttpGet("deleteuser")]
        public async Task<IActionResult> DeleteUser(User user)
        {
            User _user = await _userReadRepository.GetByIdAsync(user.Id.ToString());

            if (_user.Status == StatusEnum.Deleted)
            {
                _logger.LogWarning($"Request unsuccessful. '{_user.Username}' already deleted!..");
                return BadRequest($"'{_user.Username}' already deleted!..");
            }
                

            _user.Status = StatusEnum.Deleted;
            await _userWriteRepository.SaveAsync();

            _logger.LogInformation($"Request succesful. '{_user.Username}' deleted.");
            return Ok($"'{_user.Username}' deleted.");
        }
    }
}
