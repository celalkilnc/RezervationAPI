using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSC.Domain.Entities.Santsg.Models;
using TVSC.Infrastructure.Santsg.Model;

namespace TVSC.Application.Service
{
    public interface ILoginService
    {
        public Task<TokenModel> PostTokenAsync(LoginModel login);
    }
}
