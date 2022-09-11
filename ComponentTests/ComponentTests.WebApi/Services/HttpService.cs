using ComponentTests.WebApi.Models;
using Microsoft.Extensions.Options;

namespace ComponentTests.WebApi.Services
{
    public class HttpService
    {
        private readonly ILogger<MongoService> _logger;
        private readonly AppSettings _config;
        private readonly IHttpClientFactory _httpClientFactory;


        public HttpService(ILogger<MongoService> logger, IOptions<AppSettings> configOptions, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _config = configOptions.Value;
            _httpClientFactory = httpClientFactory;
        }


        public string MakeSomeCall()
        {
            var httpClient = _httpClientFactory.CreateClient(_config.SomeApiEndpoint);
            httpClient.BaseAddress = new Uri(_config.SomeApiEndpoint);

            var response = httpClient.GetAsync("inventory/test").Result;

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
