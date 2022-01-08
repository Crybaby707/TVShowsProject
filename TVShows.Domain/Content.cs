﻿using System.ComponentModel.DataAnnotations;

namespace TVShows.Domain;

public class Content
{
    [Key]
    public int ContentID { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }

    public int Rate { get; set; }

    public int PremiereDate { get; set; }

    public string Img { get; set; }

    public virtual Genre Genre { get; set; }

    public int GenreID { get; set; }

    public IEnumerable<UserShowList> UserShowLists { get; set; }

}
