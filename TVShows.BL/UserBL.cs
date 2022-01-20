using TVShows.DAL;
using TVShows.Domain;

namespace TVShows.BL;

public class UserBL : IUserBL
{
    private readonly IUserRepository _userRepository;

    public UserBL(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User CreateUser(User users)
    {
        return _userRepository.CreateUser(users);
    }

    public bool DeleteUser(int userId)
    {
        return _userRepository.DeleteUser(userId);
    }

    public IList<User> GetAll()
    {
        return _userRepository.GetAll();
    }

    public User GetUserById(int userId)
    {
        return _userRepository.GetUserById(userId);
    }

    public User UpdateUser(User users)
    {
        return _userRepository.UpdateUser(users);
    }
}
