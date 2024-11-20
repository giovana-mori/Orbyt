using Pi3.Models;

namespace Pi3.Repositories.Service
{
    public interface ITmdbService
    {
        Task<List<Movie>> GetMoviesFromTmdbAsync(string category);
        Task<List<Trailer>> GetTrailersAsync(int idTmdb);
        Task<List<Ator>> GetElencoAsync(int idTmdb);
        Task<List<Provider>> GetWhereToWatchAsync(int idTmdb);
        Task<List<string>> GetKeywordsAsync(int idTmdb);
    }
}