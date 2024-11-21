using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Pi3.Models;
using Pi3.Repositories;
using Pi3.Repositories.Service;
using System.Security.Claims;

namespace Pi3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService; 
        private readonly ITmdbService _tmdbService;

        public MoviesController(IMovieService movieService, ITmdbService tmdbService)
        {
            _movieService = movieService;
            _tmdbService = tmdbService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await _movieService.GetMoviesAsync();
            if (movies == null || movies.Count == 0)
            {
                return NotFound("Nenhum filme encontrado.");
            }
            return Ok(movies);
        }

        [HttpPost("fetch-from-tmdb")]
        public async Task<IActionResult> FetchAndSaveMovies([FromQuery] string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return BadRequest("A categoria não pode ser vazia.");
            }

            var movies = await _tmdbService.GetMoviesFromTmdbAsync(category);
            if (movies == null || movies.Count == 0)
            {
                return NotFound("Nenhum filme encontrado na TMDb para a categoria especificada.");
            }

            await _movieService.FetchAndSaveMovies(category, movies);

            return Ok("Filmes salvos ou atualizados com sucesso.");
        }
        

        [HttpGet("id/{id:length(24)}")]
        public async Task<IActionResult> GetAnyMovieById(string id)
        {
            var movie = await _movieService.GetAnyMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound("Filme não encontrado.");
            }
            return Ok(movie);
        }

        [HttpGet("tmdb/{idTmdb:int}")]
        public async Task<IActionResult> GetAnyMovieByTmdbId(int idTmdb)
        {
            var movie = await _movieService.GetAnyMovieByTmdbIdAsync(idTmdb);
            if (movie == null)
            {
                return NotFound("Filme não encontrado.");
            }
            return Ok(movie);
        }
        //retirar essa parte 
        [HttpGet("{collectionName}")]
        public async Task<IActionResult> GetMoviesByCollection(string collectionName)
        {
            IMongoCollection<Movie> collection;

            var movies = _movieService.GetMoviesByCollection(collectionName);

            return Ok(movies);
        }

    }
}
