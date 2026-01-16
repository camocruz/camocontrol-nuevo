using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace App.ApiClient.CS.Http
{
    public static class HttpClientFactory
    {
        public static HttpClient Crear(
            string baseUrl,
            string conniKey,
            string conniToken,
            string clientId)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Add("ConniKey", conniKey);
            client.DefaultRequestHeaders.Add("ConniToken", conniToken);
            client.DefaultRequestHeaders.Add("client_id", clientId);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}