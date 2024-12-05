using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Pi3.Dtos
{
    public class AvaliacaoCreateDto
    {   
        [Required]
        public int IdTmdb { get; set; }

        [Required]
        public string Comentario { get; set; } = string.Empty;

        [Required]
        [Range(0, 5)]
        public double Nota { get; set; }

        [Required]
        public bool Spoiler { get; set; }
    }
}
