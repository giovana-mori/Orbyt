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
    [Table("Usuario")]
    public class Usuario
    {

        [Column("id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string Id {  get; set; }

        [Column("nome")]
        private string Nome { get; set; }

        [Column("email")]
        private string Email { get; set; }

        [Column("password")]
        private string Password { get; set; }

        [Column("celular")]
        private string Celular { get; set; }

    }
}