using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Pi3.Models
{
    public class Avaliacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 

        [BsonElement("idTmdb")]
        public int IdTmdb { get; set; } 

        [BsonElement("idUsuario")]
        public string? IdUsuario { get; set; } 

        [BsonElement("comentario")]
        public string Comentario { get; set; } = string.Empty;

        [Range(0, 5)]
        [BsonElement("nota")]
        public double Nota {  get; set; }

        [BsonElement("likes")]
        public ulong Likes { get; set; } = 0;

        [BsonElement("dislikes")]
        public ulong Dislikes { get; set; } = 0;

        [BsonElement("spoiler")] 
        public bool Spoiler { get; set; } = false;

        [BsonElement("isActive")] 
        public bool isActive { get; set; } = true;
    }
}
