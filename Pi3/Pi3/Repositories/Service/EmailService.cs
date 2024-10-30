
using MailKit.Net.Smtp;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MimeKit;
using MongoDB.Driver;
using Org.BouncyCastle.Asn1.Crmf;
using Pi3.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;

namespace Pi3.Repositories.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ContextMongodb _contextMongodb;
        private readonly IGenerateToken _generateToken;

        public EmailService(IConfiguration configuration, ContextMongodb contextMongodb, IGenerateToken generateToken)
        {
            _configuration = configuration;
            _contextMongodb = contextMongodb;
            _generateToken = generateToken;
        }

        public async Task<RestResponse> EmailSender(string email, string message)
        {

            string domain = null;
            string ApiKey = null; //pedi para mim negocio email

            var options = new RestClientOptions($"https://api.mailgun.net/v3")
            {
                Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator("api", ApiKey )
            };

            var client = new RestClient(options);

            var request = new RestRequest($"{domain}/messages", RestSharp.Method.Post);
            request.AddParameter("domain", domain, ParameterType.UrlSegment);
            request.AddParameter("from", "Teste "); //pedir para mim para mandar os negocio do email
            request.AddParameter("to", email); 
            request.AddParameter("subject", "Confirmação de Cadastro");

            request.AddParameter("html", message); // Adiciona o corpo da mensagem

            // Envia a requisição e retorna a resposta
            var response = await client.ExecuteAsync(request);
            return response;
        }

        public string EmailToken(Usuario usuario)
        {
            var expiration = DateTime.UtcNow.AddDays(1);

            var token = _generateToken.GenerateToken(usuario, expiration);

            return token;
        }
    }
}
