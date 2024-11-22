using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Pi3.Models;
using Pi3.Repositories;

namespace Pi3.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ContextMongodb _conxtext;

        public UsuarioService(ContextMongodb conxtext)
        {
            _conxtext = conxtext;
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            Usuario usuario = await _conxtext.Usuario.Find(x => x.Email == email).FirstOrDefaultAsync();

            return usuario;
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

        public async Task<Usuario> Post(Usuario usuario, Stream imagemStream, string imagemNome)
        {
            ObjectId imagemId = await _conxtext.GridFS.UploadFromStreamAsync(imagemNome, imagemStream);

            usuario.ImagemId = imagemId;
            await _conxtext.Usuario.InsertOneAsync(usuario);

            return usuario;

        }
        public async Task Put(string id, Usuario usuario)
        {
            var usuarioImagem = _conxtext.Usuario.Find(x => x.Id == id).FirstOrDefault();

            usuario.ImagemId = usuarioImagem.ImagemId;

            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, usuario.Id);
            await _conxtext.Usuario.ReplaceOneAsync(filter, usuario);
        }

        public async Task PutImage(Usuario usuario, Stream imagemStream, string imagemNome)
        {
            ObjectId imagemId = await _conxtext.GridFS.UploadFromStreamAsync(imagemNome, imagemStream);

            usuario.ImagemId = imagemId;

            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, usuario.Id);
            await _conxtext.Usuario.ReplaceOneAsync(filter, usuario);
        }


        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, id);
            var update = Builders<Usuario>.Update
                    .Set(u => u.IsActive, false);
            try
            {
                await _conxtext.Usuario.UpdateOneAsync(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
