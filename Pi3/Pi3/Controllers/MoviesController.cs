using Microsoft.AspNetCore.Mvc;

namespace Pi3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ITmdbService _tmdbService;

        public MoviesController(ITmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("populares")]
        public async Task<IActionResult> GetPopularMovies() =>
            Ok(await _tmdbService.GetPopularMoviesAsync());

        [HttpGet("em-cartaz")]
        public async Task<IActionResult> GetNowPlayingMovies() =>
            Ok(await _tmdbService.GetNowPlayingMoviesAsync());

        [HttpGet("lancamentos")]
        public async Task<IActionResult> GetUpcomingMovies() =>
            Ok(await _tmdbService.GetUpcomingMoviesAsync());

        [HttpGet("melhores-avaliados")]
        public async Task<IActionResult> GetTopRatedMovies() =>
            Ok(await _tmdbService.GetTopRatedMoviesAsync());

        [HttpGet("tendencias/{timeWindow}")]
        public async Task<IActionResult> GetTrendingMovies(string timeWindow) =>
            Ok(await _tmdbService.GetTrendingMoviesAsync(timeWindow));

        [HttpGet("pesquisar")]
        public async Task<IActionResult> SearchMovies([FromQuery] string nome) =>
            Ok(await _tmdbService.SearchMoviesAsync(nome));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieDetails(int id) =>
            Ok(await _tmdbService.GetMovieDetailsAsync(id));
    }
}
