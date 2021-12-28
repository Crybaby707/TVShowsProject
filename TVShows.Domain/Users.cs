using System.ComponentModel.DataAnnotations;

namespace TVShows.Domain;

public class Users
{
    [Key]
    public int UserID { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string UserRoles { get; set; }

    public int UserRoleID { get; set; }

    public int RoleID { get; set; }

    public IEnumerable<UserShowLists>  UserShowLists { get; set; }

}

