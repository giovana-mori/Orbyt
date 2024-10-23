using Pi3.Models;

namespace Pi3.Repositories
{
    public interface IUsuarioService
    {
        public Task<List<Usuario>> GetAll();

        public Task<Usuario> GetById(string id);

        public void Post(Usuario usuario);

        public Task<Usuario> Put(string id, Usuario usuario);

        public Task<Usuario> Delete(string id);
    }
}
