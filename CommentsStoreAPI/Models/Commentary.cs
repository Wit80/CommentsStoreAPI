using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CommentsStoreAPI.Models
{
    public class Commentary
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? User { get; set; }
        public string? Email { get; set; }
        public string? Comment { get; set; }
    }
}
