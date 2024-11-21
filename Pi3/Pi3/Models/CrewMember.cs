using MongoDB.Bson.Serialization.Attributes;

namespace Pi3.Models
{
    public class CrewMember
    {
        [BsonElement("Id")]
        public int Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("Cargo")]
        public string Cargo { get; set; } = string.Empty;

        [BsonElement("Departamento")]
        public string Departamento { get; set; } = string.Empty;
    }
}
