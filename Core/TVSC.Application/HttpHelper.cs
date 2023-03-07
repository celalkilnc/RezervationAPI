using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Application
{
    public class HttpHelper
    {
        static HttpClient client;
        public HttpHelper()
        {
            client = new();
        }
        public static HttpClient HttpClientReturn()
        {
            return client;
        }
        public static HttpClient HttpClientReturn(string token)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            return client;
        }
    }
}
