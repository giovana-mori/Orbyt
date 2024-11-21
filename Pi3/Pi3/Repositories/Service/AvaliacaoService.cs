using MongoDB.Driver;
using Pi3.Models;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using NuGet.Configuration;

namespace Pi3.Repositories.Service
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IMongoCollection<Avaliacao> _avaliacoesCollection;

        public AvaliacaoService(ContextMongodb context)
        {
            _avaliacoesCollection = context.Avaliacao;
        }

        public async Task<Avaliacao> CreateReviewAsync(Avaliacao avaliacao)
        {
            await _avaliacoesCollection.InsertOneAsync(avaliacao);
            return avaliacao;
        }

        public async Task<Avaliacao> GetReviewByIdAsync(string id)
        {
            return await _avaliacoesCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Avaliacao>> GetAllReviewsAsync()
        {
            return await _avaliacoesCollection.Find(a => true).ToListAsync();
        }

        public async Task<List<Avaliacao>> GetReviewsByUserIdAsync(string idUsuario)
        {
            return await _avaliacoesCollection.Find(a => a.IdUsuario == idUsuario && a.Exibir).ToListAsync();
        }

        public async Task<List<Avaliacao>> GetReviewsByFilmIdAsync(int idTmdb)
        {
            return await _avaliacoesCollection.Find(a => a.IdTmdb == idTmdb && a.Exibir).ToListAsync();
        }

        public async Task<bool> UpdateReviewAsync(string id, Avaliacao updatedReview)
        {
            updatedReview.Id = id;
            var result = await _avaliacoesCollection.ReplaceOneAsync(a => a.Id == id, updatedReview);
            return result.MatchedCount > 0;
        }

        public async Task<bool> UpdateExibirAsync(string id, string idUsuario)
        {
          
            var filter = Builders<Avaliacao>.Filter.And(
                Builders<Avaliacao>.Filter.Eq(a => a.Id, id),
                Builders<Avaliacao>.Filter.Eq(a => a.IdUsuario, idUsuario)
            );
           
            var update = Builders<Avaliacao>.Update.Set(a => a.Exibir, false);
           
            var result = await _avaliacoesCollection.UpdateOneAsync(filter, update);
           
            return result.ModifiedCount > 0;
        }

        public async Task<int> UpdateExibirForMultipleIdsAsync(string[] ids)
        {
            var filter = Builders<Avaliacao>.Filter.In(a => a.Id, ids);
            var update = Builders<Avaliacao>.Update.Set(a => a.Exibir, false);
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
        public async Task<bool> DeleteReviewAsync(string id)
        {
            var result = await _avaliacoesCollection.DeleteOneAsync(a => a.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<bool> LikeReviewAsync(string id)
        {
            var update = Builders<Avaliacao>.Update.Inc(a => a.Likes, 1);
            var result = await _avaliacoesCollection.UpdateOneAsync(a => a.Id == id, update);
            return result.MatchedCount > 0;
        }

        public async Task<bool> DislikeReviewAsync(string id)
        {
            var update = Builders<Avaliacao>.Update.Inc(a => a.Dislikes, 1);
            var result = await _avaliacoesCollection.UpdateOneAsync(a => a.Id == id, update);
            return result.MatchedCount > 0;
        }
    }

}
