using MongoDB.Bson;
using Pi3.Dtos;
using Pi3.Models;

namespace Pi3.Repositories
{
    public interface IGenerateToken
    {
        public string GenerateToken(Usuario usuario, DateTime expiration);

        public Task<string> CreateRefreshToken(string jwt, string usuarioId);
    }
}
