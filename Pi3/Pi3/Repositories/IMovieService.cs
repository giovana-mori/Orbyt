using MongoDB.Driver;
using Pi3.Models;

namespace Pi3.Repositories.Service
{
    public interface IMovieService
    {
        public Task<List<Movie>> GetMoviesAsync();
        public Task CreateMovieAsync(Movie movie, string category);
        public Task<Movie> GetAnyMovieByIdAsync(string id);
        public Task<Movie> GetAnyMovieByTmdbIdAsync(int idTmdb);

        public Task FetchAndSaveMovies(string category, List<Movie> movies);

        public Task<List<Movie>> GetMoviesByCollection(string collectionName);

    }
}