using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
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


        public async Task Post(Usuario usuario, Stream imagemStream, string imagemNome)
        {
            ObjectId imagemId = await _conxtext.GridFS.UploadFromStreamAsync(imagemNome, imagemStream);

            usuario.ImagemId = imagemId;

            await _conxtext.Usuario.InsertOneAsync(usuario);
        }
        public async Task Put(string id, Usuario usuario)
        {
            var usuarioImagem = _conxtext.Usuario.Find(x=> x.Id == id).FirstOrDefault();

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

        public void Delete(string id)
        {
            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, id);

            _conxtext.Usuario.DeleteOneAsync(filter);
        }

        
    }
}
