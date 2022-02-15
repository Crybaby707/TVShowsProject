namespace TVShows.BL.Dtos;

public class CreateContentDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public int Rate { get; set; }

    public int PremiereDate { get; set; }

    public string Img { get; set; }
}
