using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace App.ApiClient.CS.Services
{
    public class SiesaApiClient
    {
        private readonly HttpClient _http;

        public SiesaApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> GetAsync(string relativeUrl, CancellationToken cancellationToken = default)
        {
            var response = await _http.GetAsync(relativeUrl, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}


//using System.Threading;
//using System.Threading.Tasks;

//namespace App.ApiClient.CS.Services
//{
//    public class SiesaApiClient
//    {
//        private readonly HttpClient _http;

//        public SiesaApiClient(HttpClient http)
//        {
//            _http = http;
//        }

//        public async Task<string> GetAsync(string relativeUrl, CancellationToken cancellationToken = default)
//        {
//            using (var response = await _http.GetAsync(relativeUrl, cancellationToken))
//            {
//                response.EnsureSuccessStatusCode();
//                return await response.Content.ReadAsStringAsync();
//            }
//        }
//    }
//}