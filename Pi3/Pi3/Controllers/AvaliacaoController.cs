using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Pi3.Models;
using Pi3.Repositories.Service;

namespace Pi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] Avaliacao avaliacao)
        {
            var createdReview = await _avaliacaoService.CreateReviewAsync(avaliacao);
            return CreatedAtAction(nameof(GetReviewById), new { id = createdReview.Id }, createdReview);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Avaliacao>> GetReviewById(string id)
        {
            var avaliacao = await _avaliacaoService.GetReviewByIdAsync(id);
            return avaliacao == null ? NotFound("Avaliação não encontrada.") : Ok(avaliacao);
        }

        [HttpGet]
        public async Task<ActionResult<List<Avaliacao>>> GetAllReviews()
        {
            var reviews = await _avaliacaoService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<List<Avaliacao>>> GetReviewsByUserId(string idUsuario)
        {
            var reviews = await _avaliacaoService.GetReviewsByUserIdAsync(idUsuario);
            return reviews.Count == 0 ? NotFound("Nenhuma avaliação encontrada para o usuário especificado.") : Ok(reviews);
        }

        [HttpGet("filme/{idTmdb}")]
        public async Task<ActionResult<List<Avaliacao>>> GetReviewsByFilmId(int idTmdb)
        {
            var reviews = await _avaliacaoService.GetReviewsByFilmIdAsync(idTmdb);
            return reviews.Count == 0 ? NotFound("Nenhuma avaliação encontrada para o filme especificado.") : Ok(reviews);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateReview(string id, [FromBody] Avaliacao updatedReview)
        {
            var success = await _avaliacaoService.UpdateReviewAsync(id, updatedReview);
            return success ? NoContent() : NotFound("Avaliação não encontrada.");
        }

        [HttpPatch("{id:length(24)}/Atualizar_exibir_false_id_idUsuario")]
        public async Task<IActionResult> UpdateExibir(string id, [FromBody] string idUsuario)
        {
            var success = await _avaliacaoService.UpdateExibirAsync(id, idUsuario);
            return success ? NoContent() : NotFound("Avaliação não encontrada ou usuário não autorizado.");
        }

        [HttpPatch("Atualizar_exibir_array_usuario")]
        public async Task<IActionResult> UpdateExibirForMultipleIds([FromBody] string[] ids)
        {
            var modifiedCount = await _avaliacaoService.UpdateExibirForMultipleIdsAsync(ids);
            return modifiedCount > 0 ? NoContent() : NotFound("Nenhuma avaliação foi encontrada para os IDs especificados.");
        }

        [HttpGet("filme/{idTmdb}/Ordem_MaisLikes")]
        public async Task<IActionResult> GetReviewsByFilmIdSortedByLikes(int idTmdb)
        {
            var reviews = await _avaliacaoService.GetReviewsByFilmIdSortedByLikesAsync(idTmdb);
            return Ok(reviews);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteReview(string id)
        {
            var success = await _avaliacaoService.DeleteReviewAsync(id);
            return success ? NoContent() : NotFound("Avaliação não encontrada.");
        }

        [HttpPost("{id:length(24)}/like")]
        public async Task<IActionResult> LikeReview(string id)
        {
            var success = await _avaliacaoService.LikeReviewAsync(id);
            return success ? NoContent() : NotFound("Avaliação não encontrada.");
        }

        [HttpPost("{id:length(24)}/dislike")]
        public async Task<IActionResult> DislikeReview(string id)
        {
            var success = await _avaliacaoService.DislikeReviewAsync(id);
            return success ? NoContent() : NotFound("Avaliação não encontrada.");
        }
    }

}
