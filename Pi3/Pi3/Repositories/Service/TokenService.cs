using Microsoft.IdentityModel.Tokens;
using Pi3.Models;
using Pi3.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Pi3.Repositories.Service
{
    public class TokenService : IGenerateToken
    {
        private readonly RSA _privateKey;

        public TokenService()
        {
            _privateKey = RsakeyUtils.GetPrivateKey("app.key");
        }

        public string GenerateToken(Usuario usuario, DateTime expiration)
        {
            var rsaSecurityKey = new RsaSecurityKey(_privateKey);

            var signingCredentials = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id),
                    new Claim(ClaimTypes.Role, usuario.Role),
                    new Claim(ClaimTypes.Email, usuario.Email)
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = expiration,
                Issuer = "http://localhost:5113",
                Audience = "http://localhost:5113",
                SigningCredentials = signingCredentials
            };

            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescription);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

