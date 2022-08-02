using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DaabaseSettings:ConnectionStirng"));
            var database = client.GetDatabase(configuration.GetValue<string>("DaabaseSettings:DatabaseName"));
            var Products = database.GetCollection<Product>(configuration.GetValue<string>("DaabaseSettings:CollectionName"));
            CatalogContextSeed.SeddDate(Products);
        }
        public IMongoCollection<Product> Products => throw new NotImplementedException();
    }
}
