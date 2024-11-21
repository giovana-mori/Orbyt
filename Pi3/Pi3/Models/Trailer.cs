using MongoDB.Bson.Serialization.Attributes;

namespace Pi3.Models
{
    public class Trailer
    {
        [BsonElement("Id")]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Nome")]
        public string Nome { get; set; } = string.Empty; 

        [BsonElement("Tipo")]
        public string Tipo { get; set; } = string.Empty;

        [BsonElement("Site")]
        public string Site { get; set; } = string.Empty; 

        [BsonElement("Chave")]
        public string Chave { get; set; } = string.Empty; 

        [BsonElement("LinkYouTube")]
        public string LinkYouTube { get; internal set; } = string.Empty;
    }
}
