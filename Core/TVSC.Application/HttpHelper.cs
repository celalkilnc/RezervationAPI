using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace TVSC.Application
{
    public class HttpHelper
    {
        IConfiguration _configuration;
        public HttpHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public static async Task<string> ReturnResultAsync<T>(string url, T model, string token)
        {
            HttpClient client = new();

            //Autharize 
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            //Request
            var response = await client.PostAsJsonAsync("https://preprod-services.tourvisio.com/v2/api/" + url, model);

            //Get content
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
