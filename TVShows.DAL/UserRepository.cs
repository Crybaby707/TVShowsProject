using TVShows.Data;
using TVShows.Domain;

namespace TVShows.DAL;

public class UserRepository : IUserRepository
{
    public readonly TVShowDbContext _context;

    public UserRepository(TVShowDbContext context)
    {
        _context = context;
    }

    public User CreateUser(User users)
    {
        User userCreate = users;
        _context.Users.Add(userCreate);
        _context.SaveChanges();
        return userCreate;
    }

    public IList<User> GetAll()
    {

        return _context.Users.ToList();

    }

    public User GetUserById(int userId)
    {
        var user = _context.Users.FirstOrDefault(f => f.UserID == userId);
        return user;
    }

    public bool DeleteUser(int userId)
    {
        try
        {
            User UserToDelete = _context.Users.FirstOrDefault(u => u.UserID == userId);
            if (UserToDelete == null)
            {
                return false;
            }
            _context.Users.Remove(UserToDelete);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public User UpdateUser(User users)
    {
        try
        {
            if (users == null)
            {
                return null;
            }
            _context.Users.Update(users);
            _context.SaveChanges();
            return users;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
