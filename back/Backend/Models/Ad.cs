using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Backend.Models
{
    
    public class Ad
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string SellerId { get; set; } = null!;

        public string Image {  get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
