using System.ComponentModel.DataAnnotations;

namespace TVShows.Domain;

public class UserHasRole
{
    [Key]
    public int UserRoleID { get; set; }

    public virtual User User { get; set; }

    public int UserID { get; set; }

    public virtual Role Role { get; set; }

    public int RoleID { get; set; }

}

