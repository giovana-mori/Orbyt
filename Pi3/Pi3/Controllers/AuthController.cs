using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pi3.Dtos;
using Pi3.Models;
using Pi3.Repositories;

namespace Pi3.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _generateToken;
        private readonly IEmailService _emailService;

        public AuthController(IUsuarioService usuarioService, IConfiguration config, ITokenService generateToken, IEmailService emailService)
        {
            _usuarioService = usuarioService;
            _generateToken = generateToken;
            _emailService = emailService;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto login)
        {
            var usuario = await _usuarioService.GetByEmail(login.Email);

            if (usuario != null)
            {
                if (usuario.IsConfirmed == true)
                {
                    if (!usuario.ValidarSenha(login.Password))
                    {
                        return Unauthorized();
                    }
                    var expiration = DateTime.UtcNow.AddMinutes(5);

                    var token = _generateToken.GenerateToken(usuario, expiration);

                    var refresh = await _generateToken.CreateRefreshToken(token, usuario.Id);

                    CookieOptions cookie = Cookie();

                    Response.Cookies.Append("RefreshToken", refresh, cookie);
                    Response.Cookies.Append("Jwt", token, cookie);

                    return Ok(usuario);
                }
                return Unauthorized("Confirme email para entrar");
            }
            return NotFound("Você não tem uma conta");
        }

        [HttpPost("password-reset")]
        public async Task<IActionResult> EsqueceuSenha([FromBody] string email)
        {
            var tryEmail = await _usuarioService.GetByEmail(email);

            if (tryEmail != null)
            {
                string paginaLink = $"http://localhost:3030/resetar-senha?email={email}";

                string message = $"<p>clique no link abaixo para alterar a sua senha:</p><a href='{paginaLink}'>Alterar senha</a>";
                await _emailService.EmailSender(email, message, "Esqueceu a sua senha");

                return NoContent();
            }
            return BadRequest("Voce nao esta registrado");
        }

        [HttpPut("resetar-senha/{email}")]
        public async Task<IActionResult> ResetarSenha(string email, [FromForm] AlterarSenhaDto alterarSenha)
        {
            if(alterarSenha.Senha == alterarSenha.SenhaConfimar)
            {
                var usuario = await _usuarioService.GetByEmail(email);
                var resultUpdate =await _usuarioService.PutSenha(usuario, alterarSenha.Senha);
                if (resultUpdate)
                {
                    return NoContent();
                }
            }
            return BadRequest("Senha nao batem");
        }

        [HttpPost("refresh")]
        public ActionResult RefreshToken()
        {
            if (Request.Cookies.TryGetValue("RefreshToken", out var cookie))
            {
                string? jwt = _generateToken.verifyRefreshToken(cookie);

                if(jwt != null)
                {
                    CookieOptions cookieOptions = Cookie();
                    Response.Cookies.Append("Jwt", jwt, cookieOptions);
                    return NoContent();
                }
                else
                {
                    HttpContext.Session.Clear();

                    foreach (var cookieKey in Request.Cookies.Keys)
                    {
                        Response.Cookies.Append(cookieKey, "", new CookieOptions
                        {
                            Expires = DateTime.UtcNow.AddDays(-1)
                        });
                    }
                }
            }
            return Forbid("");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public CookieOptions Cookie()
        {
            var cookie = new CookieOptions
            {
                HttpOnly = true,
                Secure = false
            };

            return cookie;
        }
    }
}
