using MongoDB.Driver;
using Pi3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pi3.Repositories.Service
{
    public class MovieService : IMovieService
    {
        private readonly ContextMongodb _context;

        public MovieService(ContextMongodb context)
        {
            _context = context;
        }
       

        public async Task<List<Movie>> GetMoviesAsync() =>
            await _context.GetMovieCollectionByCategory("FilmesPopulares").Find(movie => true).ToListAsync();

        public async Task CreateMovieAsync(Movie movie, string category)
        {
            var collection = _context.GetMovieCollectionByCategory(category);
            await collection.InsertOneAsync(movie);
        }

        public async Task FetchAndSaveMovies(string category, List<Movie> movies)
        {
            var collection = _context.GetMovieCollectionByCategory(category);

            foreach (var movie in movies)
            {
                var filter = Builders<Movie>.Filter.Eq(m => m.IdTmdb, movie.IdTmdb);

                var options = new UpdateOptions { IsUpsert = true };

                await collection.ReplaceOneAsync(filter, movie, options);
            }
        }

        public async Task<Movie> GetAnyMovieByIdAsync(string id)
        {
            var categories = new List<string>
            {
                "FilmesPopulares",
                "FilmesEmCartaz",
                "FilmesLancamentos",
                "FilmesMelhoresAvaliados",
                "FilmesTrendingDia",
                "FilmesTrendingSemana"
            };

            foreach (var category in categories)
            {
                var collection = _context.GetMovieCollectionByCategory(category);
                var movie = await collection.Find(m => m.Id == id).FirstOrDefaultAsync();
                if (movie != null)
                {
                    return movie; 
                }
            }

            return null;
        }

        public async Task<Movie> GetAnyMovieByTmdbIdAsync(int idTmdb)
        {
            var categories = new List<string>
            {
                "FilmesPopulares",
                "FilmesEmCartaz",
                "FilmesLancamentos",
                "FilmesMelhoresAvaliados",
                "FilmesTrendingDia",
                "FilmesTrendingSemana"
            };

            foreach (var category in categories)
            {
                var collection = _context.GetMovieCollectionByCategory(category);
                var movie = await collection.Find(m => m.IdTmdb == idTmdb).FirstOrDefaultAsync();
                if (movie != null)
                {
                    return movie; 
                }
            }

            return null; 
        }

        public async Task<List<Movie>> GetMoviesByCollection(string collectionName)
        {
            var collection = _context.GetMovieCollectionByCategory(collectionName);

            List<Movie> movies = await collection.Find(_ => true).ToListAsync();

            return movies;
        }

    }
}
