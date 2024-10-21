using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pi3.Models
{
    [Table("Avaliacao")]
    public class Avaliacao
    {

        [Column("id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string Id { get; set; }

        [Column("notas")]
        private string Nota { get; set; }

        [Column("comentario")]
        private string Comentario { get; set; }

        [Column("curtida")]
        private bool Curtida { get; set; }

        
    }
}
