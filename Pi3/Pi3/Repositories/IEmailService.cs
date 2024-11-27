using Pi3.Dtos;
using Pi3.Models;

namespace Pi3.Repositories
{
    public interface IEmailService
    {
        public Task EmailSender(string email, string message);

        public string EmailToken(Usuario usuario);
             
    }

}
