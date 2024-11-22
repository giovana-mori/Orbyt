using MongoDB.Bson;

namespace Pi3.Dtos
{
    public class UsuarioDto
    {
        public string? Id { get; set; }
        public string Nome { get; set; }

        public string Password { get; set; }
        
        public string Email { get; set; }

        public string Celular { get; set; }

        public ObjectId? ImagemId { get; set; }

    }
}
