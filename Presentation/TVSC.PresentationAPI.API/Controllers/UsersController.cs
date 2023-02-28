using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TVSC.Application.Repositories;
using TVSC.Domain.Entities;
using TVSC.Domain.Enumerations;
using TVSC.Persistance.Context;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly private IUserWriteRepository _userWriteRepository; 
        readonly private IUserReadRepository  _userReadRepository;      
                                                                       
        public UsersController(IUserWriteRepository userWriteRepository, 
            IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }                              

        [HttpGet("GetUsers")]
        public IQueryable<User> GetUsers()                               
        {                                                                
            //Kullanıcıları db'den çekip deleted olmayanları döner       
            var users = _userReadRepository.GetAll();                    
            return users.Where(x => x.Status != StatusEnum.Deleted);     
        }

        [HttpGet("getdeletedusers")]
        public IQueryable<User> GetDeletedUsers()
        {
            //Kullanıcıları db'den çekip deleted olmayanları döner       
            var users = _userReadRepository.GetAll();
            return users.Where(x => x.Status == StatusEnum.Deleted);
        }

        [HttpPost("adduser")]                                            
        public async Task<IActionResult> AddUser(User user)              
        {                                                                
            if (!ModelState.IsValid)                                     
               throw new Exception();

            await _userWriteRepository.AddAsync(                         
                new()                                                    
                {                            
                    Id          = user.Id,
                    Username    = user.Username, 
                    Email       = user.Email,
                    Password    = user.Password, 
                    Status      = user.Status,
                    CreatedDate = DateTime.Now,
                });                           
            await _userWriteRepository.SaveAsync();                      
            return Ok($"{user.Username} successfully added.");
        }                                                                
 
        [HttpGet("changestatus")]
        public async Task ChangeStatus(User user)                        
        {
            User _user = await _userReadRepository.GetByIdAsync(user.Id.ToString());

            if(_user.Status == StatusEnum.Deleted || !ModelState.IsValid)
                throw new Exception();

            StatusEnum state;
            if(_user.Status == StatusEnum.Active)
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

            useredit.Username = user.Username;
            useredit.Email    = user.Email;
            useredit.Password = user.Password;
            
            await _userWriteRepository.SaveAsync();
            return Ok($"'{useredit.Username}' updated");
        }                
       
        [HttpGet("deleteuser")]
        public async Task<IActionResult> DeleteUser(User user)
        {
            User _user = await _userReadRepository.GetByIdAsync(user.Id.ToString());

            if(_user.Status == StatusEnum.Deleted)
                return BadRequest($"'{_user.Username}' already deleted!..");

            _user.Status = StatusEnum.Deleted;
            await _userWriteRepository.SaveAsync();

            return Ok($"'{_user.Username}' deleted.");
        }
    }
} 
                         