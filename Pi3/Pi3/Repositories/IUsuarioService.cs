using Pi3.Dtos;
using Pi3.Models;

namespace Pi3.Repositories
{
    public interface IUsuarioService
    {
        public Task<List<Usuario>> GetAll();

        public Task<Usuario> GetById(string id);

        public Task<Usuario> GetByEmail(string email);

        public Task<Usuario> Post(UsuarioDto usuario, Stream imagemStream, string imagemNome);

        public Task Put(string id, UsuarioDto usuario);

        public Task PutImage(UsuarioDto usuario, Stream imagemStream, string imagemNome);

        public Task<bool> Delete(string id);
    }
}
