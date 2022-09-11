using ComponentTests.WebApi.Models;
using ComponentTests.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections;

namespace ComponentTests.WebApi.Controllers
{
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly ILogger<EnvironmentController> _logger;
        private readonly AppSettings _config;
        private readonly MongoService _mongoService;
        private readonly HttpService _httpService;

        public EnvironmentController(ILogger<EnvironmentController> logger, IOptions<AppSettings> configOptions, MongoService mongoService, HttpService httpService)
        {
            _logger = logger;
            _config = configOptions.Value;
            _mongoService = mongoService;
            _httpService = httpService;
        }

        [HttpGet("environment")]
        public IDictionary GetEnvironment()
        {
            return Environment.GetEnvironmentVariables();
        }

        [HttpGet("config")]
        public AppSettings GetConfig()
        {
            return _config;
        }
        
        [HttpGet("product/{id}")]
        public Product GetProduct(Guid id)
        {
            return _mongoService.Get(id);
        }

        [HttpPut("product")]
        public Guid PutProduct(Product data)
        {
           return _mongoService.Put(data);
        }
        
        [HttpGet("some-api-call")]
        public string SomeApiCall()
        {
           return _httpService.MakeSomeCall();
        }
    }
}