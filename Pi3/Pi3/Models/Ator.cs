using MongoDB.Bson.Serialization.Attributes;

namespace Pi3.Models
{
    public class Ator
    {
        [BsonElement("Id")]
        public int Id { get; set; } 

        [BsonElement("Nome")]
        public string Nome { get; set; } = string.Empty; 

        [BsonElement("Personagem")]
        public string Personagem { get; set; } = string.Empty; 

        [BsonElement("FotoCaminho")]
        public string FotoCaminho { get; set; } = string.Empty; 
    }
}
