using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Pi3.Models;
using Pi3.Repositories;
using Pi3.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Pi3.Service
{
    public class CadastroService : ICadastro
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ContextMongodb _context;
        private readonly RSA _publickey;
        private readonly TokenValidationParameters validationParameters;

        public CadastroService(IUsuarioService usuarioService, ContextMongodb contextMongodb, TokenValidationParameters validationParameters)
        {
            _usuarioService = usuarioService;
            _context = contextMongodb;
            _publickey = RsakeyUtils.GetPublicKey("app.pub");
            this.validationParameters = validationParameters;
        }

        public async Task<bool> ActivateUser(string jwt)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(jwt, validationParameters, out var validatedToken);

            var email = principal.FindFirst(ClaimTypes.Email)?.Value;
            if (validatedToken is JwtSecurityToken jwtToken)
            {
                var usuario = await _context.Usuario.Find(x => x.Email == email).FirstOrDefaultAsync();
                var filter = Builders<Usuario>.Filter.Eq(x => x.Email, usuario.Email);
                var update = Builders<Usuario>.Update
                    .Set(u => u.IsConfirmed, true);

                var result = await _context.Usuario.UpdateOneAsync(filter, update);

                if (result != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
