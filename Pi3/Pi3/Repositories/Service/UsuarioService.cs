using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using Pi3.Models;

namespace Pi3.Repositories.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ContextMongodb _conxtext;

        public UsuarioService(ContextMongodb conxtext)
        {
            _conxtext = conxtext;
        }
        public async Task<List<Usuario>> GetAll()
        {
            List<Usuario> usuario = await _conxtext.Usuario.Find(u => true).ToListAsync();

            return usuario;
        }


        public async Task<Usuario> GetById(string id)
        {
            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, id);
            var usuario = await _conxtext.Usuario.Find(filter).FirstOrDefaultAsync();

            return usuario;
        }


        public void Post(Usuario usuario)
        {
            _conxtext.Usuario.InsertOneAsync(usuario);
        }
        public void Put(string id, Usuario usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, usuario.Id);
            _conxtext.Usuario.ReplaceOneAsync(filter, usuario);
        }

        public void Delete(string id)
        {
            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, id);

            _conxtext.Usuario.DeleteOneAsync(filter);
        }
    }
}
