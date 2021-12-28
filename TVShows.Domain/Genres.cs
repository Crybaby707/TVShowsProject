using System.ComponentModel.DataAnnotations;

namespace TVShows.Domain;

public class Genres
{
    [Key]
    public int GenreID { get; set; }

    public string GenreName { get; set; }

}

