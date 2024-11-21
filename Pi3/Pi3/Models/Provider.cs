using MongoDB.Bson.Serialization.Attributes;

namespace Pi3.Models
{
    public class Provider
    {
        [BsonElement("Nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("LogoCaminho")]
        public string LogoCaminho { get; set; } = string.Empty; 
    }
}
