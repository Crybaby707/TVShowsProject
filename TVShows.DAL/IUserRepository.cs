using TVShows.Domain;

namespace TVShows.DAL;

public interface IUserRepository
{
    IList<User> GetAll();

    User CreateUser(User users);

    User UpdateUser(User users);

    bool DeleteUser(int userId);

    User GetUserById(int userId);
}
