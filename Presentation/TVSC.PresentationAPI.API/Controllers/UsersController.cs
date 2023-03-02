﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Serilog;
using TVSC.Application.Repositories;
using TVSC.Application.Service;
using TVSC.Domain.Entities;
using TVSC.Domain.Enumerations;
using TVSC.Persistance.Context;

namespace TVSC.PresentationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region ReadOnly
        readonly private IUserWriteRepository _userWriteRepository;
        readonly private IUserReadRepository _userReadRepository;
        readonly private IMailService _mailService;
        readonly private ILogger<UsersController> _logger;
        #endregion

        public UsersController(
            IUserWriteRepository userWriteRepository,
            IUserReadRepository  userReadRepository, 
            IMailService         mailService,
            ILogger<UsersController> logger)
        { 
            _userWriteRepository = userWriteRepository;
            _userReadRepository  = userReadRepository;
            _mailService         = mailService;
            _logger              = logger;
        }

        [HttpGet("GetUsers")]
        public IQueryable<User> GetUsers()
        {
            //Kullanıcıları db'den çekip deleted olmayanları döner   
            var users = _userReadRepository.GetAll();
            _logger.LogInformation("'GetUsers' method triggered *************");
            return users.Where(x => x.Status != StatusEnum.Deleted);
        }

        [HttpGet("getdeletedusers")]
        public IQueryable<User> GetDeletedUsers()
        {
            //Kullanıcıları db'den çekip deleted olmayanları döner       
            var users = _userReadRepository.GetAll();
            _logger.LogInformation("'GetDeletedUsers' method trigerred");
            return users.Where(x => x.Status == StatusEnum.Deleted);

        }

        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser(User user)
        {
            if (!ModelState.IsValid)
                throw new Exception();

            user.CreatedDate = DateTime.Now;
            await _userWriteRepository.AddAsync(user);
            await _mailService.SendMailAsync(user.Email, "User Record",
                $"<strong>{user.Username}</strong> record sucesful.Welcome.");
            await _userWriteRepository.SaveAsync();
            
            _logger.LogInformation($"[{DateTime.Now}]   Added user: {user.Username}");
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
            _logger.LogInformation($"{user.Username}'s status updated. New status: {state.ToString()}");

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
            _logger.LogInformation($"'{useredit.Username}' updated");
            return Ok($"'{useredit.Username}' updated");
        }

        [HttpGet("deleteuser")]
        public async Task<IActionResult> DeleteUser(User user)
        {
            User _user = await _userReadRepository.GetByIdAsync(user.Id.ToString());

            if (_user.Status == StatusEnum.Deleted)
                return BadRequest($"'{_user.Username}' already deleted!..");

            _user.Status = StatusEnum.Deleted;
            await _userWriteRepository.SaveAsync();
            _logger.LogInformation($"'{_user.Username}' deleted.");

            return Ok($"'{_user.Username}' deleted.");
        }
    }
}
