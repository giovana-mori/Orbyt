using Microsoft.AspNetCore.Mvc;
using Pi3.Models;
using Pi3.Repositories;


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
        public async Task<ActionResult> Cadastro([FromForm] Usuario usuario, [FromForm] IFormFile? imagem)
        {
            if (imagem == null || imagem.Length == 0)
            {
                var caminhoImagemPadrao = Path.Combine(Directory.GetCurrentDirectory(), "img/default-user.png");

                imagem = new FormFile
                (
                    baseStream: new FileStream(caminhoImagemPadrao, FileMode.Open, FileAccess.Read),
                    baseStreamOffset: 0,
                    length: new FileInfo(caminhoImagemPadrao).Length,
                    name: "defaultImage",
                    fileName: "default.jpg"
                );
            }

            var tryCadastro = _usuarioService.GetByEmail(usuario.Email);

            if (tryCadastro != null)
            {
                using (var stream = imagem.OpenReadStream())
                {
                    usuario = await _usuarioService.Post(usuario, stream, imagem.FileName);
                }

                var token = _emailService.EmailToken(usuario);

                if (token != null)
                {
                    string confirmationLink = $"http://localhost:5113/api/cadastro/confirm?token={token}";

                    string message = $"<p>Confirme seu cadastro clicando no link abaixo:</p><a href='{confirmationLink}'>Confirmar E-mail</a>";
                    await _emailService.EmailSender(usuario.Email, message);


                    return Ok();
                }
            }
            return BadRequest("O email ja esta sendo Usado");
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
