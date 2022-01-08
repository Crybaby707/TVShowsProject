using TVShows.Domain;

namespace TVShows.DAL;

public interface IUserRepository
{
    IList<User> GetAll();

    User CreateUser(User users);

    bool DeleteUser(int userId);

    User GetUserById(int userId);
}
