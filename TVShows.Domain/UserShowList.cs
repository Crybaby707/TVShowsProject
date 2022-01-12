using System.ComponentModel.DataAnnotations;
using TVShows.Domain.Enums;

namespace TVShows.Domain;

public class UserShowList
{
    [Key]
    public int UserShowListID { get; set; }

    public virtual Content Content { get; set; }

    public int ContentID { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; }

    public ListsCategoryEnum ListsCategory { get; set; }


}

