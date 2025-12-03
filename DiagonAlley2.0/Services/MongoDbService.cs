using DiagonAlley2._0.Models;
using MongoDB.Driver;

namespace DiagonAlley2._0.Services
{
    public class MongoDbService
    {

        private readonly IMongoCollection<Product> _products;
        private readonly IMongoCollection<Wizard> _wizards;

        public MongoDbService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var db = client.GetDatabase(config["MongoDB:DatabaseName"]);

            _products = db.GetCollection<Product>("Products");
            _wizards = db.GetCollection<Wizard>("Wizards");
        }
    }
}
