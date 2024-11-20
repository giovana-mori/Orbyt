using MongoDB.Bson.Serialization.Attributes;

namespace Pi3.Models
{
    public class Trailer
    {
        [BsonElement("Id")]
        public string Id { get; set; } = string.Empty; // ID do trailer

        [BsonElement("Nome")]
        public string Nome { get; set; } = string.Empty; // Nome do trailer

        [BsonElement("Tipo")]
        public string Tipo { get; set; } = string.Empty; // Tipo do vídeo (ex: Trailer, Teaser)

        [BsonElement("Site")]
        public string Site { get; set; } = string.Empty; // Site de origem (ex: YouTube)

        [BsonElement("Chave")]
        public string Chave { get; set; } = string.Empty; // Chave para acessar o vídeo no site (ex: ID do YouTube)

        [BsonElement("LinkYouTube")]
        public string LinkYouTube { get; internal set; } = string.Empty;
    }
}
