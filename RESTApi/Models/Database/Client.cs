using MongoDB.Bson.Serialization.Attributes;
using RESTApi.Interface;

namespace RESTApi.Models.Database
{
    [BsonCollection("client")]
    public class Client : Document
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string City { get; set; }
        public string Direction { get; set; }
    }
}
