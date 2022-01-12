using TVShows.Domain.Enums;

namespace TVShows.BL.Dtos;

public class AddUserShowListDto
{
    public int ContentID { get; set; }

    public int UserId { get; set; }

    public ListsCategoryEnum ListsCategory { get; set; }
}

