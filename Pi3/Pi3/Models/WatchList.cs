using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Pi3.Models
{
    public class WatchList
    {
        [BsonElement("nomeFilme"), BsonRepresentation(BsonType.String)]
        public string NomeFilme { get; set; }

        [BsonElement("idTmdb"), BsonRepresentation(BsonType.Int32)]
        public int IdTmdb { get; set; }
    }
}
