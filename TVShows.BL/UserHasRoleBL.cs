using TVShows.DAL;
using TVShows.Domain;

namespace TVShows.BL;

public class UserHasRoleBL : IUserHasRoleBL
{
    private readonly IUserHasRoleRepository _userHasRoleRepository;

    public UserHasRoleBL(IUserHasRoleRepository userHasRoleRepository)
    {
        _userHasRoleRepository = userHasRoleRepository;
    }

    public UserHasRole AddUserRole(UserHasRole userHasRole)
    {
        return _userHasRoleRepository.AddUserRole(userHasRole);
    }

    public bool DeleteUserRole(int userRoleId)
    {
        return _userHasRoleRepository.DeleteUserRole(userRoleId);
    }

    public IList<UserHasRole> GetAll()
    {
        return _userHasRoleRepository.GetAll();
    }

    public UserHasRole GetUserRoleById(int userRoleId)
    {
        return _userHasRoleRepository.GetUserRoleById(userRoleId);
    }

    public UserHasRole UpdateUserRole(UserHasRole userHasRole)
    {
        return _userHasRoleRepository.UpdateUserRole(userHasRole);
    }
}

