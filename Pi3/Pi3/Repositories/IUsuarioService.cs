using Pi3.Models;

namespace Pi3.Repositories
{
    public interface IUsuarioService
    {
        public Task<List<Usuario>> GetAll();

        public Task<Usuario> GetById(string id);

        public Task Post(Usuario usuario, Stream imagemStream, string imagemNome);

        public Task Put(string id, Usuario usuario);

        public Task PutImage(Usuario usuario, Stream imagemStream, string imagemNome);

        public void Delete(string id);
    }
}
