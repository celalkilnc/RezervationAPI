using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Application
{
    public class HttpHelper
    {

        public static async Task<string> ReturnResultAsync<T>(string url, T model, string token)
        {
            HttpClient client = new();

            //Autharize 
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            //Request
            var response = await client.PostAsJsonAsync(url, model);

            //Get content
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
