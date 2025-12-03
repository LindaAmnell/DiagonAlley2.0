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
        public double Discount { get; set; } = 0.0;
        public List<CartItem> Cart { get; set; } = new();
        public bool IsAdmin { get; set; } = false;


        public double CartTotal()
        {
            return Cart.Sum(c => c.TotalPrice);
        }

        public void UpdateDiscount()
        {
            Discount = Level switch
            {
                WizardLevel.Gold => 0.30,
                WizardLevel.Silver => 0.20,
                WizardLevel.Bronze => 0.10,
                _ => 0.0
            };
        }

    }
}
