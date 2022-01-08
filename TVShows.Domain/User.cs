using System.ComponentModel.DataAnnotations;

namespace TVShows.Domain;

public class User
{
    [Key]
    public int UserID { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public IEnumerable<UserHasRole> UserRole { get; set; }

    public IEnumerable<UserShowList>  UserShowLists { get; set; }

}

    