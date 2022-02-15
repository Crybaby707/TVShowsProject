using NSubstitute;
using System.Collections.Generic;
using TVShows.DAL;
using TVShows.Domain;
using Xunit;


namespace TVShows.BL.Tests;

public class GenreBLTest
{
    private GenreBL _genreBL;
    private IGenreRepository _genreRepository = Substitute.For<IGenreRepository>();

    [Fact]
    public void GetAll_ReturnsCorrectData()
    {
        //arrange

        var s = new List<Genre>
        {
            new Genre
            {
                GenreID = 1,
                GenreName = "Horror"
            },

            new Genre
            {
                GenreID = 2,
                GenreName = "Multfilm"
            }
        };

        _genreRepository.GetAll().Returns(s);
        _genreBL = new GenreBL(_genreRepository);

        //act
        var result = _genreBL.GetAll();

        //assert
        Assert.Equal("Horror", result[0].GenreName);
        Assert.Equal(2, result[1].GenreID);
        Assert.Equal(2, result.Count);
    }


}