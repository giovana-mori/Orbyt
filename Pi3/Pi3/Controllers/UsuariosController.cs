using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pi3.Dtos;
using Pi3.Models;
using Pi3.Repositories;

namespace Pi3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(ContextMongodb conxtext, IUsuarioService usuario)
        {
            _usuarioService = usuario;
        }

        [HttpGet]
        public async Task<ActionResult<Usuario>> Get()
        {
            var usuario = await _usuarioService.GetAll();

            return Ok(usuario);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(string id)
        {

            var usuario = await _usuarioService.GetById(id);

            if (usuario is null)
            {
                return NotFound("UserNotFound");
            }

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromForm] UsuarioDto usuarioDto, [FromForm] IFormFile? imagem)
        {
            if (id != usuarioDto.Id)
            {
                return BadRequest();
            }

            if (imagem != null && imagem.Length > 0)
            {
                using (var stream = imagem.OpenReadStream())
                {
                    await _usuarioService.PutImage(usuarioDto, stream, imagem.FileName);

                    return Ok();
                }
            }

            await _usuarioService.Put(id, usuarioDto);

            return Ok();
        }

        [HttpPost("watch-list")]
        public async Task<IActionResult> AddToWatchList([FromForm] WatchFavoriteDto watchListDto)
        {
            Request.Cookies.TryGetValue("Jwt", out var cookie);
            if (cookie != null)
            {
                List<WatchList> usuarioList = await _usuarioService.AddWatchList(watchListDto, cookie);
                if (usuarioList != null)
                {
                    return Ok(usuarioList);
                }
            }
            return BadRequest();
        }

        [HttpDelete("remove-watchlist/{tmdbId}")]
        public async Task<IActionResult> RemoveWatchList([FromRoute] int tmdbId)
        {
            Request.Cookies.TryGetValue("jwt", out var cookie);
            if (cookie != null)
            {
                bool tryRemove = await _usuarioService.RemoveFromWatchList(cookie, tmdbId);
                if (tryRemove)
                {
                    return NoContent();
                }
            }
            return BadRequest();
        }

        [HttpPost("favorite")]
        public async Task<IActionResult> AddToFavorite([FromBody] WatchFavoriteDto watchFavorite)
        {
            Request.Cookies.TryGetValue("Jwt", out var cookie);
            if (cookie != null)
            {
                List<Favorite> usuarioList = await _usuarioService.AddFavorites(watchFavorite, cookie);
                if (usuarioList != null)
                {
                    return Ok(usuarioList);
                }
            }
            return BadRequest();
        }

        [HttpDelete("remove-favorite/{tmdbId}")]
        public async Task<IActionResult> RemoveFavorite([FromRoute] int tmdbId)
        {
            Request.Cookies.TryGetValue("jwt", out var cookie);
            if (cookie != null)
            {
                bool tryRemove = await _usuarioService.RemoveFromFavorite(cookie, tmdbId);
                if (tryRemove)
                {
                    return NoContent();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var tryDelete = await _usuarioService.Delete(id);

            if (tryDelete == false)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
