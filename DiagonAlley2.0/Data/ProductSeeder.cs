using DiagonAlley2._0.Models;
using DiagonAlley2._0.Services;
using Models.Enum;

namespace Data
{
    public static class ProductSeeder
    {
        private const string ProductCollection = "Products";

        public static async Task SeedAsync(MongoDbService mongo)
        {
            var existingProducts = await mongo.GetAllAsync<Product>(ProductCollection);
            if (existingProducts.Any())
                return;

            var products = new List<Product>
            {
                // 🪄 WANDS
                new Product
                {
                    Name = "Elder Wand",
                    Price = 999,
                    Type = ProductType.Wand,
                    Core = "Thestral hair",
                    Length = 15,

                },
                new Product
                {
                    Name = "Holly Wand",
                    Price = 499,
                    Type = ProductType.Wand,
                    Core = "Phoenix feather",
                    Length = 11,

                },
                new Product
                {
                    Name = "Yew Wand",
                    Price = 549,
                    Type = ProductType.Wand,
                    Core = "Phoenix feather",
                    Length = 13,

                },

                // 🧪 POTIONS
                new Product
                {
                    Name = "Polyjuice Potion",
                    Price = 299,
                    Type = ProductType.Potion,
                    Effect = "Transforms the drinker",
                    Duration = 60,

                },
                new Product
                {
                    Name = "Felix Felicis",
                    Price = 399,
                    Type = ProductType.Potion,
                    Effect = "Grants extraordinary luck",
                    Duration = 30,

                },
                new Product
                {
                    Name = "Veritaserum",
                    Price = 249,
                    Type = ProductType.Potion,
                    Effect = "Forces the drinker to tell the truth",
                    Duration = 10,

                },

                // 🧹 BROOMSTICKS
                new Product
                {
                    Name = "Nimbus 2000",
                    Price = 799,
                    Type = ProductType.Broomstick,
                    Speed = 120,
                    Manufacturer = "Nimbus Racing Brooms",

                },
                new Product
                {
                    Name = "Firebolt",
                    Price = 1299,
                    Type = ProductType.Broomstick,
                    Speed = 200,
                    Manufacturer = "Firebolt Company",

                },
                new Product
                {
                    Name = "Cleansweep Seven",
                    Price = 699,
                    Type = ProductType.Broomstick,
                    Speed = 110,
                    Manufacturer = "Cleansweep Broom Co.",

                }
            };

            foreach (var product in products)
            {
                await mongo.CreateAsync(ProductCollection, product);
            }
        }
    }
}
