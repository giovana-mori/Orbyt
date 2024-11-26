using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pi3.Models
{
    public class RefreshToken
    {
        [BsonId]
        [BsonElement("id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("jwt"), BsonRepresentation(BsonType.String)]
        public string Jwt { get; set; }

        [BsonElement("expireAt"), BsonRepresentation(BsonType.DateTime)]
        public DateTime ExpireAt { get; set; }

        [BsonElement("usuarioId"), BsonRepresentation(BsonType.String)]
        public string UsuarioId {  get; set; }

        public bool isExpired()
        {
            return ExpireAt.CompareTo(DateTime.UtcNow) < 0;
        }

        public RefreshToken(string jwt, DateTime expireAt, string usuarioId) 
        {
            Jwt = jwt;
            ExpireAt = expireAt;
            UsuarioId = usuarioId;
        }
    }
}
