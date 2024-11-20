using MongoDB.Bson.Serialization.Attributes;

namespace Pi3.Models
{
    public class Ator
    {
        [BsonElement("Id")]
        public int Id { get; set; } // ID do ator no TMDb

        [BsonElement("Nome")]
        public string Nome { get; set; } = string.Empty; // Nome do ator

        [BsonElement("Personagem")]
        public string Personagem { get; set; } = string.Empty; // Nome do personagem interpretado

        [BsonElement("FotoCaminho")]
        public string FotoCaminho { get; set; } = string.Empty; // Caminho para a foto do ator
    }
}
