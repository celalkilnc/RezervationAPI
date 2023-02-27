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
                                                                                    
        [HttpPost("adduser")]                                                       
        public async Task<IActionResult> AddUser(User user)                        
        {                                                                           
            if (!ModelState.IsValid)                                                
            {                                                                       
                throw new Exception();                                              
            }                                                                       
            await _userWriteRepository.AddAsync(                                    
                new()                                                               
                {                                                                   
                    Username = user.Username,                                       
                    Email = user.Email,                                             
                    Password = user.Password,                                       
                    Status = user.Status                                            
                });                                                                 
            await _userWriteRepository.SaveAsync();                                 
            return Ok($"{user.Username} successfully added.");                      
        }                                                                           
                                                  
        [HttpGet("changestatus")]                                               
        public async Task ChangeStatus(User user)                               
        {
            User _user = await _userReadRepository.GetByIdAsync(user.Id.ToString());
            if(_user.Status == StatusEnum.Deleted || !ModelState.IsValid)
            {            
                throw new Exception();
            }            

            StatusEnum s;
            if(_user.Status == StatusEnum.Active) s = StatusEnum.Passive;
            else s = StatusEnum.Active;

            user.Status = s;
            _userWriteRepository.Update(user);
            await _userWriteRepository.SaveAsync();
        }                
  
        [HttpPost("updateuser")]
        public async Task<bool> UpdateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            User useredit = await _userReadRepository.GetByIdAsync(user.Id.ToString());
                         
            useredit.Id          = user.Id;
            useredit.Username    = user.Username;
            useredit.Status      = user.Status;       
            useredit.Email       = user.Email;        
            useredit.Password    = user.Password;     
            useredit.CreatedDate = user.CreatedDate;

            bool result = _userWriteRepository.Update(useredit);
            await _userWriteRepository.SaveAsync();
 
            return result;
        }                
                         
        [HttpDelete("Delete")]
        public async Task DeleteUser(string id)
        {                
            await UpdateStatusByIdAsync(id, StatusEnum.Deleted);
            
        }

        #region NonAction
        private async Task UpdateStatusByIdAsync(string id, StatusEnum newEnum)
        {
            User user = await _userReadRepository.GetByIdAsync(id);
            user.Status = newEnum;
            await _userWriteRepository.SaveAsync();
        }
        #endregion
    }                    
}                        
                         