using MongoDB.Bson;
using MongoDB.Driver;

namespace DiagonAlley2._0.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _db;

        public MongoDbService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            _db = client.GetDatabase(config["MongoDB:DatabaseName"]);
        }

        private IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }

        public async Task<List<T>> GetAllAsync<T>(string collectionName)
        {
            return await GetCollection<T>(collectionName).Find(_ => true).ToListAsync();
        }

        public async Task<T?> GetByIdAsync<T>(string collectionName, string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return await GetCollection<T>(collectionName).Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync<T>(string collectionName, T entity)
        {
            await GetCollection<T>(collectionName).InsertOneAsync(entity);
        }

        public async Task UpdateAsync<T>(string collectionName, string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await GetCollection<T>(collectionName).ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync<T>(string collectionName, string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await GetCollection<T>(collectionName).DeleteOneAsync(filter);
        }
    }
}
