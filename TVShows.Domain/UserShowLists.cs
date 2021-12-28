using System.ComponentModel.DataAnnotations;
using TVShows.Domain.Enums;

namespace TVShows.Domain;

public class UserShowLists
{
    [Key]
    public int UserShowListID { get; set; }

    public virtual Contents Content { get; set; }

    public int ContentsID { get; set; }

    public int UserId { get; set; }

    public virtual Users User { get; set; }

    public ListsCategoryEnum ListsCategory { get; set; }


}

