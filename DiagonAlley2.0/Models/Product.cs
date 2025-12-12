using Models.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiagonAlley2._0.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        [BsonRepresentation(BsonType.String)]
        public ProductType Type { get; set; }
        public string? ImageUrl { get; set; }

        // Wand
        public string? Core { get; set; }
        public int? Length { get; set; }

        // Potion
        public string? Effect { get; set; }
        public int? Duration { get; set; }

        // Broomstick
        public int? Speed { get; set; }
        public string? Manufacturer { get; set; }

    }
}
