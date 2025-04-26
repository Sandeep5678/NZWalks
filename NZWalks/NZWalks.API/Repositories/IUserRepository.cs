namespace NZWalks.API.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AutenticateAsync(string username, string password);
    }
}
