using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pi3.Models
{
    public class Avaliacao
    {

        [BsonId]
        [BsonElement("id"), BsonRepresentation(BsonType.ObjectId)]
        private string Id { get; set; }

        [BsonElement("nota"), BsonRepresentation(BsonType.String)]
        private string Nota { get; set; }

        [BsonElement("comentario"), BsonRepresentation(BsonType.String)]
        private string Comentario { get; set; }

        private bool Curtida { get; set; }

        
    }
}
