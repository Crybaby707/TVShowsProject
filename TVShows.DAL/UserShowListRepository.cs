using TVShows.Data;
using TVShows.Domain;

namespace TVShows.DAL;

public class UserShowListRepository : IUserShowListRepository
{
    public readonly TVShowDbContext _context;

    public UserShowListRepository(TVShowDbContext context)
    {
        _context = context;

    }

    public UserShowList AddUserShowList(UserShowList userShowList)
    {
        try
        {
        UserShowList userShowListCreate = userShowList;
        _context.UsersShowLists.Add(userShowListCreate);
        _context.SaveChanges();
        return userShowListCreate;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool DeleteUserShowList(int userShowListId)
    {
        try
        {
            UserShowList UserShowListToDelete = _context.UsersShowLists.FirstOrDefault(u => u.UserShowListID == userShowListId);
            if (UserShowListToDelete == null)
            {
                return false;
            }
            _context.UsersShowLists.Remove(UserShowListToDelete);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IList<UserShowList> GetAll()
    {
        return _context.UsersShowLists.ToList();
    }

    public UserShowList GetUserShowListById(int userShowListId)
    {
        var userShowList = _context.UsersShowLists.FirstOrDefault(f => f.UserShowListID == userShowListId);
        return userShowList;
    }

    public UserShowList UpdateUserShowList(UserShowList userShowList)
    {
        try
        {
            if (userShowList == null)
            {
                return null;
            }
            _context.UsersShowLists.Update(userShowList);
            _context.SaveChanges();
            return userShowList;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
