using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Pi3.Dtos
{
    public class UsuarioDto
    {
        public string? Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Celular { get; set; }

        public ObjectId? ImagemId { get; set; }

    }
}
