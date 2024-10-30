using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using Org.BouncyCastle.Crypto.Parameters;
using Pi3.Models;
using Pi3.Repositories;
using Pi3.Repositories.Service;
using Pi3.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

namespace Pi3.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration _config;
        private readonly IGenerateToken _generateToken;
        private readonly TokenValidationParameters _validationParameters;

        public AuthController(IUsuarioService usuarioService, IConfiguration config, IGenerateToken generateToken, TokenValidationParameters tokenValidationParameters)
        {
            _usuarioService = usuarioService;
            _generateToken = generateToken;
            _config = config;
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
                return Ok(new { Token = token });
            }

            return Unauthorized("Confirme email para entrar");
        }

        
    }
}
