using Pi3.Dtos;
using Pi3.Models;

namespace Pi3.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario fromUsuarioDto(this UsuarioDto usuarioDto)
        {
            return new Usuario
            {
                Nome = usuarioDto.Nome,
                Password = usuarioDto.Password,
                Email = usuarioDto.Email,
                Celular = usuarioDto.Celular,
                ImagemId = usuarioDto.ImagemId
            };
        }
    }
}
