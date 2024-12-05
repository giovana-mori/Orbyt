using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using Pi3.Dtos;
using Pi3.Mappers;
using Pi3.Models;
using Pi3.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pi3.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ContextMongodb _conxtext;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public UsuarioService(ContextMongodb conxtext, TokenValidationParameters tokenValidationParameters)
        {
            _conxtext = conxtext;
            _tokenValidationParameters = tokenValidationParameters;
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

        public async Task<Usuario> Post(UsuarioDto usuarioDto, Stream imagemStream, string imagemNome)
        {
            ObjectId imagemId = await _conxtext.GridFS.UploadFromStreamAsync(imagemNome, imagemStream);

            var usuario = usuarioDto.fromUsuarioDto();

            usuario.ImagemId = imagemId;
            usuario.SenhaSecure();
            
            await _conxtext.Usuario.InsertOneAsync(usuario);

            return usuario;

        }
        public async Task Put(string id, UsuarioDto usuarioDto)
        {
            var usuarioImagem = _conxtext.Usuario.Find(x => x.Id == id).FirstOrDefault();

            usuarioDto.ImagemId = usuarioImagem.ImagemId;

            var usuario = usuarioDto.fromUsuarioDto();

            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, usuario.Id);
            await _conxtext.Usuario.ReplaceOneAsync(filter, usuario);
        }

        public async Task PutImage(UsuarioDto usuarioDto, Stream imagemStream, string imagemNome)
        {
            ObjectId imagemId = await _conxtext.GridFS.UploadFromStreamAsync(imagemNome, imagemStream);

            usuarioDto.ImagemId = imagemId;

            var usuario = usuarioDto.fromUsuarioDto();

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

        public async Task<bool> PutSenha(Usuario usuario, string senha)
        {
            usuario.Password = senha;
            usuario.SenhaSecure();
            var filter = Builders<Usuario>.Filter.Eq(x => x.Email, usuario.Email);
            var update = Builders<Usuario>.Update.Set(x=> x.Password, usuario.Password);
            var teste = await _conxtext.Usuario.UpdateOneAsync(filter, update);
            return teste.ModifiedCount > 0;
        }

        public async Task<List<WatchList>?> AddWatchList(WatchFavoriteDto watchFavorite, string jwt)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(jwt, _tokenValidationParameters, out var validatedToken);
            if(validatedToken is JwtSecurityToken token)
            {
                var watchList = watchFavorite.toWatchListModel();

                var usuarioId = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

                Usuario usuario = await GetById(usuarioId);

                usuario.WatchList.Add(watchList);

                var filter = Builders<Usuario>.Filter.Eq(x=>x.Id, usuarioId);
                var update = Builders<Usuario>.Update.Set(x=> x.WatchList, usuario.WatchList);

                await _conxtext.Usuario.UpdateOneAsync(filter, update);
                return usuario.WatchList;   
            }
            return null;
        }

        public async Task<bool> RemoveFromWatchList(string jwt, int tmdbId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(jwt, _tokenValidationParameters, out var validatedToken);
            if (validatedToken is JwtSecurityToken token)
            {
                var usuarioId = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

                Usuario usuario = await GetById(usuarioId);

                if (usuario == null)
                {
                    return false;
                }

                var filter = Builders<Usuario>.Filter.Eq(x => x.Id, usuarioId);

                var update = Builders<Usuario>.Update.PullFilter("watchList", Builders<Usuario>.Filter.Eq("idTmdb", tmdbId));

                await _conxtext.Usuario.UpdateOneAsync(filter, update);

                return true;
            }

            return false;
        }

        public async Task<List<Favorite>?> AddFavorites(WatchFavoriteDto watchFavorite, string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(jwt, _tokenValidationParameters, out var validatedToken);
            if (validatedToken is JwtSecurityToken token)
            {
                var favorite = watchFavorite.ToFavoriteModel();

                var usuarioId = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

                Usuario usuario = await GetById(usuarioId);

                usuario.Favorite.Add(favorite);

                var filter = Builders<Usuario>.Filter.Eq(x => x.Id, usuarioId);
                var update = Builders<Usuario>.Update.Set(x => x.Favorite, usuario.Favorite);

                await _conxtext.Usuario.UpdateOneAsync(filter, update);
                return usuario.Favorite;
            }
            return null;
        }

        public async Task<bool> RemoveFromFavorite(string jwt, int tmdbId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(jwt, _tokenValidationParameters, out var validatedToken);
            if (validatedToken is JwtSecurityToken token)
            {
                var usuarioId = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

                Usuario usuario = await GetById(usuarioId);

                if (usuario == null)
                {
                    return false;
                }

                var filter = Builders<Usuario>.Filter.Eq(x => x.Id, usuarioId);

                var update = Builders<Usuario>.Update.PullFilter("favorite", Builders<Usuario>.Filter.Eq("idTmdb", tmdbId));

                await _conxtext.Usuario.UpdateOneAsync(filter, update);

                return true;
            }

            return false;
        }
    }
}
