using System.ComponentModel.DataAnnotations;

namespace TVShows.Domain;

public class Genre
{
    [Key]
    public int GenreID { get; set; }

    public string GenreName { get; set; }

    public IEnumerable<ContentGenre> ContentGenres { get; set; }

}

