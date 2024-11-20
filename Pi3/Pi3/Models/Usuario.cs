using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pi3.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonElement("id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome"), BsonRepresentation(BsonType.String)]
        public string Nome { get; set; }

        [BsonElement("email"), BsonRepresentation(BsonType.String)]
        public string Email { get; set; }

        [BsonElement("password"),  BsonRepresentation(BsonType.String)]
        public string Password { get; set; }

        [BsonElement("celular"), BsonRepresentation(BsonType.String)]
        public string Celular { get; set; }

        [BsonElement("isConfirmed"), BsonRepresentation(BsonType.Boolean)]
        public bool IsConfirmed { get; set; } = false;

        [BsonElement("role"), BsonRepresentation(BsonType.String)]
        public string Role { get; set; } = "User";

        public ObjectId? ImagemId { get; set; }

        [BsonElement("isActive"), BsonRepresentation(BsonType.Boolean)]
        public bool IsActive { get; set; } = true;
    }

}