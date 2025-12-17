using DiagonAlley2._0.Models;
using DiagonAlley2._0.Services;

namespace Services
{
    public class CartService
    {
        private readonly MongoDbService _db;
        private readonly LoginService _login;

        public CartService(MongoDbService db, LoginService login)
        {
            _db = db;
            _login = login;
        }

        public Wizard? Wizard => _login.CurrentWizard;

        public async Task LoadCartAsync()
        {
            if (Wizard == null) return;

            foreach (var item in Wizard.Cart)
            {
                item.Product = await _db.GetByIdAsync<Product>(
                    "Products",
                    item.ProductId
                );
            }

            Wizard.UpdateDiscount();
        }

        public decimal Subtotal =>
            Wizard?.CartTotal() ?? 0;

        public decimal DiscountAmount =>
            Subtotal * (Wizard?.Discount ?? 0);

        public decimal Total =>
            Subtotal - DiscountAmount;

        public async Task Increase(CartItem item)
        {
            item.Quantity++;
            await Save();
        }

        public async Task Decrease(CartItem item)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
                await Save();
            }
        }

        public async Task Remove(CartItem item)
        {
            Wizard?.Cart.Remove(item);
            await Save();
        }

        public async Task Clear()
        {
            Wizard?.Cart.Clear();
            await Save();
        }

        private async Task Save()
        {
            if (Wizard != null)
            {
                await _db.UpdateAsync("Wizards", Wizard.Id!, Wizard);
            }
        }

        public async Task AddToCart(Product product)
        {
            if (Wizard == null)
                throw new InvalidOperationException("No logged in wizard");

            var item = Wizard.Cart.FirstOrDefault(
                c => c.ProductId == product.Id);

            if (item == null)
            {
                Wizard.Cart.Add(new CartItem
                {
                    ProductId = product.Id!,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }

            await Save();
        }

    }
}


