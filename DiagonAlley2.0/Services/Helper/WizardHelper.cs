using DiagonAlley2._0.Models;
using DiagonAlley2._0.Services;

namespace Services.Helper
{
    public static class WizardHelper
    {
        public static void ApplyDiscount(Wizard wizard)
        {
            wizard.UpdateDiscount();
        }

        public static async Task LoadCartDataAsync(Wizard wizard, MongoDbService db)
        {
            foreach (var item in wizard.Cart)
            {
                item.Product = await db.GetByIdAsync<Product>("Products", item.ProductId);
            }
        }

        public static bool ValidatePassword(Wizard wizard, string password)
        {
            return wizard.Password == password;
        }

        public static async Task AddToCart(Wizard wizard,
            Product product,
            MongoDbService db)
        {
            var item = wizard.Cart.FirstOrDefault(
                c => c.ProductId == product.Id);

            if (item == null)
            {
                wizard.Cart.Add(new CartItem
                {
                    ProductId = product.Id!,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }

            await db.UpdateAsync("Wizards", wizard.Id!, wizard);
        }
    }
}
