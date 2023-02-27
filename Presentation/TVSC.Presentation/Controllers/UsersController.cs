using Microsoft.AspNetCore.Mvc;
using TVSC.Application.Repositories;
using TVSC.Domain.Entities;

namespace TVSC.Presentation.Controllers
{
    public class UsersController : Controller
    {
        readonly private IUserWriteRepository _userWriteRepository;
        readonly private IUserReadRepository _userReadRepository;

        public UsersController(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task Get()
        {
            await _userWriteRepository.AddRangeAsync(new()
            {
                new(){ Id = Guid.NewGuid(), Username = "User4", CreatedDate = DateTime.Now, Password = "123", Email = "User4@mail", Status = true },
                new(){ Id = Guid.NewGuid(), Username = "User5", CreatedDate = DateTime.Now, Password = "123", Email = "User5@mail", Status = false },
                new(){ Id = Guid.NewGuid(), Username = "User6", CreatedDate = DateTime.Now, Password = "123", Email = "User6@mail", Status = true }
            });
            var count =  _userWriteRepository.SaveAsync();
        }

    }
}
