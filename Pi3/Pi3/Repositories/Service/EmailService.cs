
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
using System.Net;

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

        public async Task EmailSender(string email, string message)
        {
            

            var fromEmail = Environment.GetEnvironmentVariable("fromEmail", EnvironmentVariableTarget.User);
            var pw = Environment.GetEnvironmentVariable("senhaEmail", EnvironmentVariableTarget.User);
            var porta = 587;

            

            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress("teste", fromEmail));
            mensagem.To.Add(MailboxAddress.Parse(email));
            mensagem.Subject = "Confirmar Email";
            var builder = new BodyBuilder { TextBody = string.Empty, HtmlBody = message };
            mensagem.Body = builder.ToMessageBody();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await smtpClient.ConnectAsync("smtp.gmail.com", porta, MailKit.Security.SecureSocketOptions.StartTls).ConfigureAwait(false);
            await smtpClient.AuthenticateAsync(fromEmail, pw).ConfigureAwait(false);
            await smtpClient.SendAsync(mensagem).ConfigureAwait(false);
            await smtpClient.DisconnectAsync(true).ConfigureAwait(false);

        }

        public string EmailToken(Usuario usuario)
        {
            var expiration = DateTime.UtcNow.AddDays(1);

            var token = _generateToken.GenerateToken(usuario, expiration);

            return token;
        }
    }
}
