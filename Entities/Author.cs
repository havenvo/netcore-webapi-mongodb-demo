using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetCoreApiMongodb.Entities
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name {get; set; }
    }
}