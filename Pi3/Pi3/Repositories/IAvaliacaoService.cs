using Pi3.Models;

namespace Pi3.Repositories.Service
{
    public interface IAvaliacaoService
    {
        Task<Avaliacao> CreateReviewAsync(Avaliacao avaliacao);
        Task<Avaliacao> GetReviewByIdAsync(string id);
        Task<List<Avaliacao>> GetAllReviewsAsync();
        Task<List<Avaliacao>> GetReviewsByUserIdAsync(string idUsuario);
        Task<List<Avaliacao>> GetReviewsByFilmIdAsync(int idTmdb);
        Task<List<Avaliacao>> GetReviewsByFilmIdSortedByLikesAsync (int idTmdb);        
        Task<bool> UpdateReviewAsync(string id, Avaliacao updatedReview);
        Task<bool> UpdateExibirAsync(string id, string idUsuario);
        Task<int> UpdateExibirForMultipleIdsAsync(string[] ids);
        Task<bool> DeleteReviewAsync(string id);
        Task<bool> LikeReviewAsync(string id);
        Task<bool> DislikeReviewAsync(string id);
    }
}