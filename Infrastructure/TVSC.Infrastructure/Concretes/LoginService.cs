using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSC.Application.Service;
using TVSC.Domain.Entities.Santsg.Models;
using TVSC.Infrastructure.Santsg.Model;

namespace TVSC.Infrastructure.Concretes
{
    public class LoginService : ILoginService
    {
        readonly IConfiguration _configuration;
        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<TokenModel> PostTokenAsync(LoginModel login)
        {
            throw new NotImplementedException();
        }
    }
}
