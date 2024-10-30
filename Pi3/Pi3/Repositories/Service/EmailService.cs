
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
        //public async Task EmailSender(string email, string subject, string message)
        //{
        //    var confirm = new MimeMessage();
        //    confirm.From.Add(new MailboxAddress("Arthur", _configuration["Mailgun:SenderEmail"]));
        //    confirm.To.Add(new MailboxAddress("", email));
        //    confirm.Subject = subject;
        //    confirm.Body = new TextPart("html") { Text = message };

        //    using var smtp = new SmtpClient();
        //    await smtp.ConnectAsync("smtp.mailgun.org", 587, false);
        //    await smtp.AuthenticateAsync("api", _configuration["Mailgun:ApiKey"]);
        //    await smtp.SendAsync(confirm);
        //    await smtp.DisconnectAsync(true);
        //}

        public async Task<RestResponse> EmailSender(string email, string message)
        {

            var domain = "sandbox6a02e476256a45d590116309ffcd6be7.mailgun.org";
            var ApiKey = "a374eaea6732d2892ab17eecb1d3f595-72e4a3d5-1f6f514d";

            var options = new RestClientOptions($"https://api.mailgun.net/v3")
            {
                Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator("api", ApiKey )
            };

            var client = new RestClient(options);

            var request = new RestRequest($"{domain}/messages", RestSharp.Method.Post);
            request.AddParameter("domain", domain, ParameterType.UrlSegment);
            request.AddParameter("from", "Teste <mailgun@sandbox6a02e476256a45d590116309ffcd6be7.mailgun.org>"); // Remetente autorizado no Mailgun
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
