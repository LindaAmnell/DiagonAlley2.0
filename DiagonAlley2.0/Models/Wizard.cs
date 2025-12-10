using DiagonAlley2._0.Models.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiagonAlley2._0.Models
{
    public class Wizard
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.String)]
        public WizardLevel Level { get; set; } = WizardLevel.Regular;

        public decimal Discount { get; set; } = 0.0m;

        public List<CartItem> Cart { get; set; } = new();

        public bool IsAdmin { get; set; } = false;

        public decimal CartTotal()
        {
            return Cart.Sum(c => c.TotalPrice);
        }

        public void UpdateDiscount()
        {
            Discount = Level switch
            {
                WizardLevel.Gold => 0.30m,
                WizardLevel.Silver => 0.20m,
                WizardLevel.Bronze => 0.10m,
                _ => 0.00m
            };
        }
    }
}
