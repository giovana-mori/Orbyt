using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Pi3.Models;
using Pi3.Repositories;
using Pi3.Repositories.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            _usuarioService.Post(usuario);
            
            return StatusCode(StatusCodes.Status201Created, null);
        }

        [HttpPut("{id}")]
        public ActionResult<Usuario> Put(string id, [FromBody] Usuario usuario)
        {
            if(id != usuario.Id)
            {
                return BadRequest();
            }

            _usuarioService.Put(id, usuario);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(string id)
        {
            _usuarioService.Delete(id);

            return Ok();
        }
    }
}
