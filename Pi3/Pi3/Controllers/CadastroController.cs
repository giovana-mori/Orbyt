using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pi3.Dtos;
using Pi3.Models;
using Pi3.Repositories;
using Pi3.Repositories.Service;
using System.Security.Claims;

namespace Pi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IUsuarioService _usuarioService;
        private readonly ICadastro _cadastro;

        public CadastroController(IEmailService emailService, IUsuarioService usuarioService, ICadastro cadastro)
        {
            this._emailService = emailService;
            this._usuarioService = usuarioService;
            _cadastro = cadastro;
        }

        [HttpPost]
        public async Task<ActionResult> Cadastro([FromForm] Usuario usuario, [FromForm] IFormFile imagem)
        {
            if (imagem == null || imagem.Length == 0)
            {
                return BadRequest("Imagem não enviada.");
            }

            
            using (var stream = imagem.OpenReadStream())
            {
                usuario = await _usuarioService.Post(usuario, stream, imagem.FileName);
            }

            var token = _emailService.EmailToken(usuario);  

            if (token != null)
            {
                string confirmationLink = $"http://localhost:5113/api/cadastro/confirm?token={token}";

                var message = $"<p>Confirme seu cadastro clicando no link abaixo:</p><a href='{confirmationLink}'>Confirmar E-mail</a>";
                await _emailService.EmailSender(usuario.Email, message);


                return Ok(token);
            }
            return BadRequest();
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token)
        {
            bool verificacao = await _cadastro.ActivateUser(token);

            if (verificacao is false)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
