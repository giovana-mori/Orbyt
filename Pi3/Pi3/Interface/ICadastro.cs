namespace Pi3.Repositories
{
    public interface ICadastro
    {
        public Task<bool> ActivateUser(string jwt);
    }
}
