using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pi3.Dtos;
using Pi3.Models;
using Pi3.Repositories.Service;

namespace Pi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpPost("criar-avaliacao")]
        public async Task<IActionResult> CreateReview([FromBody] AvaliacaoCreateDto  avaliacao)
        {
            Request.Cookies.TryGetValue("Jwt", out var cookie);
            if (cookie != null)
            { 
                var createdReview = await _avaliacaoService.CreateReviewAsync(avaliacao, cookie);
                if (createdReview != null)
                { 
                    return CreatedAtAction(nameof(GetReviewById), new { id = createdReview.Id }, createdReview);
                }
            }
            return BadRequest();
        }
        
        [HttpGet("usuario-review")]
        public async Task<ActionResult<List<Avaliacao>>> GetReviewsByUserId()
        {
            if(Request.Cookies.TryGetValue("Jwt", out var cookies))
            {
                var reviews = await _avaliacaoService.GetReviewsByUserIdAsync(cookies);
                if(reviews != null)
                {
                    return Ok(reviews);
                }

                return NotFound("Nenhuma avaliação encontrada para o usuário especificado.");
            }
            return BadRequest();
        }

        [HttpGet("filme-reviews/{idTmdb}")]
        public async Task<ActionResult<List<Avaliacao>>> GetReviewsByFilmId([FromRoute] int idTmdb)
        {
            var reviews = await _avaliacaoService.GetReviewsByFilmIdAsync(idTmdb);
            if(reviews.Count == 0)
            {
                return NotFound("Nenhuma avaliação encontrada para o filme especificado.");
            }
            return Ok(reviews);
        }

        [HttpPut("update-avaliacao/{id}")]
        public async Task<IActionResult> UpdateReview([FromRoute] string id, [FromBody] AvaliacaoUpdateDto updatedReview)
        {
            if(id == updatedReview.Id)
            {
                var success = await _avaliacaoService.UpdateReviewAsync(id, updatedReview);
                if (success)
                {
                    return NoContent();
                }
                return NotFound("Avaliação não encontrada.");
            }
            return BadRequest();
        }

            [HttpDelete("disable-avaliacao/{id}")]
        public async Task<IActionResult> DisableAvaliacao(string id)
        {
            if (Request.Cookies.TryGetValue("Jwt", out var cookie)) 
            {
                var success = await _avaliacaoService.Disable(id, cookie);
                if (success) 
                {
                    return NoContent();
                }
                return NotFound("Avaliação não encontrada ou usuário não autorizado.");
            }
            return BadRequest(); 
        }

        [HttpDelete("disable-multiplos")]
        public async Task<IActionResult> DisableManyIsActive([FromBody] string[] ids)
        {
            var modifiedCount = await _avaliacaoService.DisableIsActives(ids);
            if (modifiedCount > 0)
            {
                return NoContent();
            }
            return NotFound("Nenhuma avaliação foi encontrada para excluir");
        }

        [HttpGet("sort-like/{idTmdb}")]
        public async Task<IActionResult> GetReviewsSortedByLikes([FromRoute] int idTmdb)
        {
            var reviews = await _avaliacaoService.GetReviewsByFilmIdSortedByLikesAsync(idTmdb);
            return Ok(reviews);
        }

        [HttpPut("like/{id}")]
        public async Task<IActionResult> LikeReview(string id)
        {
            var success = await _avaliacaoService.LikeReviewAsync(id);
            return success ? NoContent() : NotFound("Avaliação não encontrada.");
        }

        [HttpPut("dislike{id}")]
        public async Task<IActionResult> DislikeReview(string id)
        {
            var success = await _avaliacaoService.DislikeReviewAsync(id);
            return success ? NoContent() : NotFound("Avaliação não encontrada.");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<Avaliacao>> GetReviewById(string id)
        {
            var avaliacao = await _avaliacaoService.GetReviewByIdAsync(id);
            return avaliacao == null ? NotFound("Avaliação não encontrada.") : Ok(avaliacao);
        }
    }

}
