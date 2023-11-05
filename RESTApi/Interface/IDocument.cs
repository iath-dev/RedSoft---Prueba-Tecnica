using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RESTApi.Interface
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }

    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;
    }
}
