using Pi3.Dtos;
using Pi3.Models;

namespace Pi3.Repositories.Service
{
    public interface IAvaliacaoService
    {
        Task<Avaliacao>? CreateReviewAsync(AvaliacaoCreateDto avaliacao, string jwt);
        Task<Avaliacao> GetReviewByIdAsync(string id);
        Task<List<Avaliacao>> GetReviewsByUserIdAsync(string jwt);
        Task<List<Avaliacao>> GetReviewsByFilmIdAsync(int idTmdb);
        Task<List<Avaliacao>> GetReviewsByFilmIdSortedByLikesAsync (int idTmdb);        
        Task<bool> UpdateReviewAsync(string id, AvaliacaoUpdateDto updatedReview);
        Task<bool> Disable(string id, string cookie);
        Task<int> DisableIsActives(string[] ids);
        Task<bool> LikeReviewAsync(string id);
        Task<bool> DislikeReviewAsync(string id);
    }
}