namespace TVShows.WEB.Services
{
    public interface IIdentityService
    {
        string Authenticate(string email, string password);
    }
}
