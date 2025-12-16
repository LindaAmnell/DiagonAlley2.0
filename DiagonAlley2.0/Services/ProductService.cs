using DiagonAlley2._0.Models;

namespace DiagonAlley2._0.Services
{
    public class ProductService
    {
        private readonly MongoDbService _db;
        private const string Collection = "Products";

        public ProductService(MongoDbService db)
        {
            _db = db;
        }

        public Task<List<Product>> GetAll()
            => _db.GetAllAsync<Product>(Collection);

        public Task Create(Product product)
            => _db.CreateAsync(Collection, product);

        public Task Update(Product product)
            => _db.UpdateAsync(Collection, product.Id!, product);

        public Task Delete(string id)
            => _db.DeleteAsync<Product>(Collection, id);
    }
}
