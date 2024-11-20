using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pi3.Models;
using Pi3.Repositories;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Pi3.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IGenerateToken _generateToken;
        private readonly TokenValidationParameters _validationParameters;

        public AuthController(IUsuarioService usuarioService, IConfiguration config, IGenerateToken generateToken, TokenValidationParameters tokenValidationParameters)
        {
            _usuarioService = usuarioService;
            _generateToken = generateToken;
            _validationParameters = tokenValidationParameters;
        }


        [HttpPost]
        public async Task<ActionResult> Login([FromForm] LoginModel login)
        {
            var usuario = await _usuarioService.GetByEmail(login.Email);
            var tokenHandler = new JwtSecurityTokenHandler();

            if (usuario.IsConfirmed == true)
            {
                if (usuario == null || usuario.Password != login.Password)
                {
                    return Unauthorized();
                }
                var expiration = DateTime.UtcNow.AddMinutes(5);

                var token = _generateToken.GenerateToken(usuario, expiration);

                var cookie = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                };

                Response.Cookies.Append("Jwt", token, cookie);

                return Ok(new { Token = token });
            }


            return Unauthorized("Confirme email para entrar");
        }

        
    }
}
