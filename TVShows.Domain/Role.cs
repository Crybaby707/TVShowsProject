using System.ComponentModel.DataAnnotations;

namespace TVShows.Domain;

public class Role
{
    [Key]
    public int RoleID { get; set; }

    public string Code { get; set; }

    public string RoleName { get; set; }
}

