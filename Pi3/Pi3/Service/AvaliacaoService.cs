using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Pi3.Dtos;
using Pi3.Mappers;
using Pi3.Models;
using Pi3.Repositories.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace Pi3.Service
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IMongoCollection<Avaliacao> _avaliacoesCollection;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AvaliacaoService(ContextMongodb context, TokenValidationParameters tokenValidationParameters)
        {
            _avaliacoesCollection = context.Avaliacao;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<Avaliacao>? CreateReviewAsync(AvaliacaoCreateDto avaliacaoDto, string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(jwt, _tokenValidationParameters, out var validatedToken);
            if (validatedToken is JwtSecurityToken token)
            {
                var idUsuario = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

                var avaliacao = AvaliacaoMapper.FromAvaliacaoDto(avaliacaoDto);

                avaliacao.IdUsuario = idUsuario;

                await _avaliacoesCollection.InsertOneAsync(avaliacao);
                return avaliacao;
            }
            return null;
        }

        public async Task<Avaliacao> GetReviewByIdAsync(string id)
        {
            return await _avaliacoesCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Avaliacao>?> GetReviewsByUserIdAsync(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(jwt, _tokenValidationParameters, out var validatedToken);
            if (validatedToken is JwtSecurityToken token)
            {
                var idUsuario = principal.FindFirst(ClaimTypes.NameIdentifier).Value;
                return await _avaliacoesCollection.Find(a => a.IdUsuario == idUsuario && a.isActive).ToListAsync();
            }
            return null;
        }

        public async Task<List<Avaliacao>> GetReviewsByFilmIdAsync(int idTmdb)
        {
            return await _avaliacoesCollection.Find(a => a.IdTmdb == idTmdb && a.isActive).ToListAsync();
        }

        public async Task<bool> UpdateReviewAsync(string id, AvaliacaoUpdateDto updatedReview)
        {
            var filter = Builders<Avaliacao>.Filter.Eq(x=> x.Id, id);
            var update = Builders<Avaliacao>.Update
                .Set(x => x.Comentario, updatedReview.Comentario)
                .Set(x => x.Nota, updatedReview.Nota)
                .Set(x => x.Spoiler, updatedReview.Spoiler);

            var result = await _avaliacoesCollection.UpdateOneAsync(filter, update);
            return result.MatchedCount > 0;
        }

        public async Task<bool> Disable(string id, string cookie)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(cookie, _tokenValidationParameters, out var validatedToken);
            if (validatedToken is JwtSecurityToken token)
            {
                var idUsuario = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

                var filter = Builders<Avaliacao>.Filter.And(
                Builders<Avaliacao>.Filter.Eq(a => a.Id, id),
                Builders<Avaliacao>.Filter.Eq(a => a.IdUsuario, idUsuario));

                var update = Builders<Avaliacao>.Update.Set(a => a.isActive, false);

                var result = await _avaliacoesCollection.UpdateOneAsync(filter, update);
                return result.ModifiedCount > 0;
            }
            return false;
        }

        public async Task<int> DisableIsActives(string[] ids)
        {
            var filter = Builders<Avaliacao>.Filter.In(a => a.Id, ids);
            var update = Builders<Avaliacao>.Update.Set(a => a.isActive, false);
            var result = await _avaliacoesCollection.UpdateManyAsync(filter, update);
            return (int)result.ModifiedCount;
        }

        public async Task<List<Avaliacao>> GetReviewsByFilmIdSortedByLikesAsync(int idTmdb)
        {

            var filter = Builders<Avaliacao>.Filter.Eq(a => a.IdTmdb, idTmdb);


            var reviews = await _avaliacoesCollection.Find(filter)
                .Sort(Builders<Avaliacao>.Sort.Descending(a => a.Likes))
                .ToListAsync();

            return reviews;
        }

        public async Task<bool> LikeReviewAsync(string id)
        {
            var update = Builders<Avaliacao>.Update.Inc(a =>(int)a.Likes, 1);
            var result = await _avaliacoesCollection.UpdateOneAsync(a => a.Id == id, update);
            return result.MatchedCount > 0;
        }

        public async Task<bool> DislikeReviewAsync(string id)
        {
            var update = Builders<Avaliacao>.Update.Inc(a => (int)a.Dislikes, 1);
            var result = await _avaliacoesCollection.UpdateOneAsync(a => a.Id == id, update);
            return result.MatchedCount > 0;
        }
    }

}
