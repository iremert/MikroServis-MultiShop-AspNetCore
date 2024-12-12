using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShopCatalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }   //ilişki yok ya bunda
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
