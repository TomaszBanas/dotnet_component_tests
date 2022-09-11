namespace ComponentTests.WebApi.Models
{
    public class CatalogDatabaseSettings
    {
        public string ConnectionString { get; set; } = default!;
        public string DatabaseName { get; set; } = default!;
        public string CollectionName { get; set; } = default!;

    }


    public class AppSettings
    {
        public CatalogDatabaseSettings CatalogDatabaseSettings { get; set; } = default!;
        public string SomeApiEndpoint { get; set; } = default!;
    }
}
