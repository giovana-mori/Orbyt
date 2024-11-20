using MongoDB.Bson.Serialization.Attributes;

namespace Pi3.Models
{
    public class Provider
    {
        [BsonElement("Nome")]
        public string Nome { get; set; } = string.Empty; // Nome do provedor (ex: Netflix, Amazon Prime)

        [BsonElement("LogoCaminho")]
        public string LogoCaminho { get; set; } = string.Empty; // Caminho do logo do provedor
    }
}
