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
    }
}
