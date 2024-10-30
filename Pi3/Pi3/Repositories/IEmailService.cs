using MongoDB.Driver;
using Pi3.Models;
using RestSharp;

namespace Pi3.Repositories
{
    public interface IEmailService
    {
        public Task<RestResponse> EmailSender(string email, string message);

        public string EmailToken(Usuario usuario);
             
    }

}
