namespace DiagonAlley2._0.Services
{
    using DiagonAlley2._0.Models;
    using global::Models.Enum;

    public class ProductService
    {
        private readonly MongoDbService _db;
        private const string CollectionName = "Products";

        public ProductService(MongoDbService db)
        {
            _db = db;
        }

        public async Task CreateAsync(Product product)
        {
            ValidateProduct(product);
            await _db.CreateAsync(CollectionName, product);
        }

        public async Task UpdateAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Id))
                throw new ArgumentException("Product id is required");

            ValidateProduct(product);

            await _db.UpdateAsync<Product>(CollectionName, product.Id, product);
        }


        public async Task DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Product id is required");

            await _db.DeleteAsync<Product>(CollectionName, id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.GetAllAsync<Product>(CollectionName);
        }

        private static void ValidateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new InvalidOperationException("Name is required");

            if (product.Price <= 0)
                throw new InvalidOperationException("Price must be greater than 0");

            switch (product.Type)
            {
                case ProductType.Wand:
                    if (string.IsNullOrWhiteSpace(product.Core))
                        throw new InvalidOperationException("Wand core is required");

                    if (product.Length is null or <= 0)
                        throw new InvalidOperationException("Wand length must be greater than 0");
                    break;

                case ProductType.Potion:
                    if (string.IsNullOrWhiteSpace(product.Effect))
                        throw new InvalidOperationException("Potion effect is required");

                    if (product.Duration is null or <= 0)
                        throw new InvalidOperationException("Potion duration must be greater than 0");
                    break;

                case ProductType.Broomstick:
                    if (product.Speed is null or <= 0)
                        throw new InvalidOperationException("Broomstick speed must be greater than 0");

                    if (string.IsNullOrWhiteSpace(product.Manufacturer))
                        throw new InvalidOperationException("Broomstick manufacturer is required");
                    break;
            }
        }
    }

}
