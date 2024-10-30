using Pi3.Models;

namespace Pi3.Repositories
{
    public interface IGenerateToken
    {
        public string GenerateToken(Usuario usuario, DateTime expiration);
    }
}
