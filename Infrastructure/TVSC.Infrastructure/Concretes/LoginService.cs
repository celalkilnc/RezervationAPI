using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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
        
        public async Task<TokenModel> PostTokenAsync(LoginModel login)
        {
            string postUrl = _configuration["TVServiceAdress"] + _configuration["Santsg:TokenService"];
            var json = JsonSerializer.Serialize(login);
            HttpClient client = new HttpClient();

            var response = await client.PostAsJsonAsync(postUrl, login);
            var result = await response.Content.ReadAsStringAsync();
            // Response içindeki veriyi okumak için ekstra metod gereklidir

            BodyModel bodyModel = JsonSerializer.Deserialize<BodyModel>(result);
            
            TokenModel tokenModel = new(){
                token     = bodyModel.body.token,
                expiresOn = bodyModel.body.expiresOn,
                tokenId   = bodyModel.body.tokenId
            };

            return tokenModel;
        }
    }
}
