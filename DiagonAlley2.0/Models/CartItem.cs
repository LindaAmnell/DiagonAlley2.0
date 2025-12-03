using MongoDB.Bson.Serialization.Attributes;

namespace DiagonAlley2._0.Models
{


    public class CartItem
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Amount { get; set; }

        [BsonIgnore]
        public double TotalPrice => Price * Amount;
    }

}
