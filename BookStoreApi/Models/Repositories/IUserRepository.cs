namespace BookStoreApi.Models.Repositories
{
    public interface IUserRepository
    {
        string AuthenticateAdmin(string username, string password);
        string AuthenticateUser(string username, string password);
    }
}
