using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pi3.Models
{
    public class Avaliacao
    {

        [BsonId]
        [BsonElement("id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nota"), BsonRepresentation(BsonType.String)]
        public string Nota { get; set; }

        [BsonElement("comentario"), BsonRepresentation(BsonType.String)]
        public string Comentario { get; set; }

        [BsonElement("curtida"), BsonRepresentation(BsonType.Boolean)]
        public bool Curtida { get; set; }

        [BsonElement("isActive"), BsonRepresentation(BsonType.Boolean)]
        public bool IsActive { get; set; }

        
    }
}
