using TVShows.Domain;

namespace TVShows.BL
{
    public interface IUserAuthBL : IBaseBL
    {
        User GetUserById(int id);

        User GetByEmailAndPassword(string email, string password);
    }
}
