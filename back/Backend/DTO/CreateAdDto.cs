using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.DTO
{
    public class CreateAdDto
    {
            public string Title { get; set; } = null!;
            public string Description { get; set; } = null!;
            public int Price { get; set; }
            public string CategoryId { get; set; } = null!;
            public string SellerId { get; set; } = null!;
            public string Image { get; set; } = null!;
            public string Location { get; set; } = null!;
    }
}

