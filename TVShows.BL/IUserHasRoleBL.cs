using TVShows.Domain;

namespace TVShows.BL;

public interface IUserHasRoleBL
{
    IList<UserHasRole> GetAll();

    UserHasRole AddUserRole(UserHasRole userHasRole);

    UserHasRole UpdateUserRole(UserHasRole userHasRole);

    bool DeleteUserRole(int userRoleId);

    UserHasRole GetUserRoleById(int userRoleId);
}

