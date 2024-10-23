using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    }

}