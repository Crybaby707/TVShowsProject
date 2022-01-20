using TVShows.Data;
using TVShows.Domain;

namespace TVShows.DAL;

public class UserHasRoleRepository : IUserHasRoleRepository
{
    public readonly TVShowDbContext _context;

    public UserHasRoleRepository(TVShowDbContext context)
    {
        _context = context;

    }

    public UserHasRole AddUserRole(UserHasRole userHasRole)
    {
        try
        {
            UserHasRole userAddRole = userHasRole;
            if (userAddRole == null)
            {
                return null;
            }
            _context.UserHasRoles.Add(userAddRole);
            _context.SaveChanges();
            return userAddRole;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public IList<UserHasRole> GetAll()
    {

        return _context.UserHasRoles.ToList();

    }

    public UserHasRole GetUserRoleById(int userRoleId)
    {
        var userRole = _context.UserHasRoles.FirstOrDefault(f => f.UserRoleID == userRoleId);
        return userRole;

    }

    public bool DeleteUserRole(int userRoleId)
    {
        try
        {
            UserHasRole userRoleToDelete = _context.UserHasRoles.FirstOrDefault(u => u.UserRoleID == userRoleId);
            if (userRoleToDelete == null)
            {
                return false;
            }
            _context.UserHasRoles.Remove(userRoleToDelete);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public UserHasRole UpdateUserRole(UserHasRole userHasRole)
    {
        try
        {
            if (userHasRole == null)
            {
                return null;
            }
            _context.UserHasRoles.Update(userHasRole);
            _context.SaveChanges();
            return userHasRole;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
