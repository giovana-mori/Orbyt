using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pi3.Models;
using Pi3.Repositories;

namespace Pi3.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {

        private readonly ContextMongodb _conxtext;
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(ContextMongodb conxtext, IUsuarioService usuario)
        {
            _conxtext = conxtext;
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
        public async Task<ActionResult> Put(string id, [FromForm] Usuario usuario, [FromForm] IFormFile? imagem)
        {
            if(id != usuario.Id)
            {
                return BadRequest();
            }

            if (imagem != null && imagem.Length > 0)
            {
                using(var stream = imagem.OpenReadStream())
                {
                    await _usuarioService.PutImage(usuario, stream, imagem.FileName);

                    return Ok();
                }
            }

            await _usuarioService.Put(id, usuario);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var tryDelete = await _usuarioService.Delete(id);

            if (tryDelete == false)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
