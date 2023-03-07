using System.Text.Json;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TVSC.Application.Service;
using TVSC.Infrastructure.Santsg.Model;
using TVSC.Domain.Entities.Santsg.Models;

namespace TVSC.Infrastructure.Concretes
{
    public class LoginService : ILoginService
    {
        readonly ILogger<LoginService> _logger;
        readonly IConfiguration _configuration;

        HttpClient Client = new();
        public LoginService(IConfiguration configuration, ILogger<LoginService> logger)
        {
            _logger= logger;
            _configuration = configuration;
        }

        public async Task<TokenModel> PostTokenAsync(LoginModel login)
        {
            string postUrl = _configuration["TVServiceAdress"] + _configuration["Santsg:TokenService"];

            BodyModel bodyModel = new();
            string result = await HttpRequestAsync<LoginModel>(postUrl, login);
            bodyModel = JsonSerializer.Deserialize<BodyModel>(result);

            if (bodyModel.body == null)
               throw new Exception("Error: 'Body' is null!..");

            TokenModel tokenModel = new(){
                token     = bodyModel.body.token,
                expiresOn = bodyModel.body.expiresOn,
                tokenId   = bodyModel.body.tokenId
            };
            return tokenModel;
        }

        public async Task GetArrivalAsync(ArrivalAutoCompModel model)
        {
            string postUrl = _configuration["TVServiceAdress"] + _configuration["Santsg:GetArrivalAutoComp"];
            var result = HttpRequestAsync<ArrivalAutoCompModel>(postUrl, model);
        }

        private async Task<string> HttpRequestAsync<T>(string url, T model)
        {
            var response = await Client.PostAsJsonAsync(url, model);
            var result = await response.Content.ReadAsStringAsync();
            // Response içindeki veriyi okumak için ekstra metod gereklidir

            return result;
        }

    }
}
