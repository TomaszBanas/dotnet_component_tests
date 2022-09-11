using ComponentTests.WebApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ComponentTests.WebApi.Services
{
    public class MongoService
    {
        private readonly ILogger<MongoService> _logger;
        private readonly AppSettings _config;

        public IMongoCollection<Product> Products { get; }

        public MongoService(ILogger<MongoService> logger, IOptions<AppSettings> configOptions)
        {
            _logger = logger;
            _config = configOptions.Value;

            var client = new MongoClient(_config.CatalogDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(_config.CatalogDatabaseSettings.DatabaseName);
            Products = database.GetCollection<Product>(_config.CatalogDatabaseSettings.CollectionName);


        }

        public Guid Put(Product data)
        {
            data.Id = Guid.NewGuid();
            Products.InsertOneAsync(data).GetAwaiter().GetResult();
            return data.Id;
        }

        public Product Get(Guid key)
        {
            return Products.Find(p => p.Id == key).FirstOrDefault();
        }

    }
}
