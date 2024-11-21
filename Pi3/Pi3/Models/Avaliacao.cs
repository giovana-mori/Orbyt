using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pi3.Models
{
    public class Avaliacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 

        [BsonElement("IdTmdb")]
        public int IdTmdb { get; set; } 

        [BsonElement("IdUsuario")]
        public string IdUsuario { get; set; } = string.Empty; 

        [BsonElement("Comentario")]
        public string Comentario { get; set; } = string.Empty; 

        [BsonElement("Likes")]
        public int Likes { get; set; } 

        [BsonElement("Dislikes")]
        public int Dislikes { get; set; } 

        [BsonElement("Spoiler")] 
        public bool Spoiler { get; set; } 

        [BsonElement("Exibir")] 
        public bool Exibir { get; set; } = true;
    }
}
