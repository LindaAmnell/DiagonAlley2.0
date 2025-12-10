using MongoDB.Bson.Serialization.Attributes;

namespace DiagonAlley2._0.Models
{


    public class CartItem
    {
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; }

        [BsonIgnore]
        public Product? Product { get; set; }

        [BsonIgnore]
        public decimal TotalPrice => (Product?.Price ?? 0) * Quantity;
    }


}
