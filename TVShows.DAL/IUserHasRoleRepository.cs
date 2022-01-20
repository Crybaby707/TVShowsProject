using TVShows.Domain;

namespace TVShows.DAL;

public interface IUserHasRoleRepository
{
    IList<UserHasRole> GetAll();

    UserHasRole AddUserRole(UserHasRole userHasRole);

    UserHasRole UpdateUserRole(UserHasRole userHasRole);

    bool DeleteUserRole(int userRoleId);

    UserHasRole GetUserRoleById(int userRoleId);

}

