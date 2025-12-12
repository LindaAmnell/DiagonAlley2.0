using Models.Enum;

namespace DiagonAlley2._0.Services.Helper
{

    public static class ProductImageHelper
    {
        public static string GetImage(ProductType type)
        {
            return type switch
            {
                ProductType.Wand => "/images/products/wand.jpg",
                ProductType.Potion => "/images/products/potion.jpg",
                ProductType.Broomstick => "/images/products/broomstick.jpg",
                _ => "/images/products/default.png"
            };
        }

    }
}
