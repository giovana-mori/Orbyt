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

        [HttpGet("category")]
        public async Task<IActionResult> GetCategoryOfMovie([FromQuery] int page, [FromQuery] string category)
        {
            var movie = await _tmdbService.GetMovieByCategory(page, category);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("sorted")]
        public async Task<IActionResult> GetMovieSorted(
            [FromQuery] int page,
            [FromQuery] int[]? genero,
            [FromQuery] string? sortAno,
            [FromQuery] bool? movieType)
        {
            
            if (movieType != null && sortAno != null)
            {
                return BadRequest("Nao e possivel pesquisar por ano e por mais recente/antigo");
            }
            var movie = await _tmdbService.GetBySort(page, genero, sortAno, movieType);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }


        [HttpGet("pesquisar/{nome}")]
        public async Task<IActionResult> SearchMovies([FromRoute] string nome)
        {
            var movie =await _tmdbService.SearchMoviesAsync(nome);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            var movie = await _tmdbService.GetMovieDetailsAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
    }
}
