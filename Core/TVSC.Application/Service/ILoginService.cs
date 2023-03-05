using TVSC.Domain.Entities.Santsg.Models;
using TVSC.Infrastructure.Santsg.Model;

namespace TVSC.Application.Service
{
    public interface ILoginService
    {
        public Task<TokenModel> PostTokenAsync(LoginModel login);
    }
}
