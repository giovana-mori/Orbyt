using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
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
        private readonly RSA _privateKey;

        public AuthController(IUsuarioService usuarioService, IConfiguration config)
        {
            _usuarioService = usuarioService;
            _privateKey = RsakeyUtils.GetPrivateKey("app.key");
            _config = config;
        }


        [HttpPost]
        public async Task<ActionResult> Login([FromForm] LoginModel login)
        {
            var usuario = await _usuarioService.GetByEmail(login.Email);

            if (usuario == null || usuario.Password != login.Password)
            {
                return Unauthorized();
            }

            var token = generateToken(usuario);
            return Ok(new { Token = token });

        }

        private string generateToken(Usuario usuario) 
        {
            var rsaSecurityKey = new RsaSecurityKey(_privateKey);

            var signingCredentials = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id),
                    new Claim(ClaimTypes.Role, usuario.Role)
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = "http://localhost:5113",
                Audience = "http://localhost:5113",
                SigningCredentials = signingCredentials
            };

            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescription);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
