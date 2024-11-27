using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        private readonly TokenValidationParameters _validationParameters;

        public AuthController(IUsuarioService usuarioService, IConfiguration config, ITokenService generateToken, TokenValidationParameters tokenValidationParameters)
        {
            _usuarioService = usuarioService;
            _generateToken = generateToken;
            _validationParameters = tokenValidationParameters;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromForm] LoginModel login)
        {
            var usuario = await _usuarioService.GetByEmail(login.Email);

            if (usuario != null)
            {
                if (usuario.IsConfirmed == true)
                {
                    if (usuario == null || usuario.Password != login.Password)
                    {
                        return Unauthorized();
                    }
                    var expiration = DateTime.UtcNow.AddMinutes(5);

                    var token = _generateToken.GenerateToken(usuario, expiration);

                    var refresh = await _generateToken.CreateRefreshToken(token, usuario.Id);

                    CookieOptions cookie = Cookie();

                    Response.Cookies.Append("RefreshToken", refresh, cookie);
                    Response.Cookies.Append("Jwt", token, cookie);

                    return Ok(new { Token = token });
                }
                return Unauthorized("Confirme email para entrar");
            }
            return NotFound("Você não tem uma conta");
        }

        [HttpPost("refresh")]
        public async Task<ActionResult> RefreshToken()
        {
            if (Request.Cookies.TryGetValue("RefreshToken", out var cookie))
            {
                string jwt = _generateToken.verifyRefreshToken(cookie);

                if(jwt != null)
                {
                    CookieOptions cookieOptions = Cookie();
                    Response.Cookies.Append("Jwt", jwt, cookieOptions);
                    return Ok("");
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
