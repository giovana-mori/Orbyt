using MailKit.Net.Smtp;
using MimeKit;
using Pi3.Dtos;
using Pi3.Mappers;
using Pi3.Models;
using Pi3.Repositories;

namespace Pi3.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ContextMongodb _contextMongodb;
        private readonly ITokenService _generateToken;

        public EmailService(IConfiguration configuration, ContextMongodb contextMongodb, ITokenService generateToken)
        {
            _configuration = configuration;
            _contextMongodb = contextMongodb;
            _generateToken = generateToken;
        }

        public async Task EmailSender(string email, string message, string subject)
        {


            var fromEmail = Environment.GetEnvironmentVariable("fromEmail", EnvironmentVariableTarget.User);
            var pw = Environment.GetEnvironmentVariable("senhaEmail", EnvironmentVariableTarget.User);
            var porta = 587;



            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress("Owner", fromEmail));
            mensagem.To.Add(MailboxAddress.Parse(email));
            mensagem.Subject = subject;
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
