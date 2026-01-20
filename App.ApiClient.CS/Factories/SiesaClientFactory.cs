using App.ApiClient.CS.Config;
using App.ApiClient.CS.Http;
using App.ApiClient.CS.Services;

namespace App.ApiClient.CS.Factories
{
    public class SiesaClientFactory
    {
        private readonly SiesaConfig _config;

        public SiesaClientFactory(SiesaConfig config)
        {
            _config = config;
        }

        public SiesaApiServiceBase CreateBaseService()
        {
            var http = HttpClientFactory.Crear(
                _config.BaseUrl,
                _config.ConniKey,
                _config.ConniToken,
                _config.ClientId
            );

            var apiClient = new SiesaApiClient(http);
            return new SiesaApiServiceBase(apiClient);
        }
    }
}
