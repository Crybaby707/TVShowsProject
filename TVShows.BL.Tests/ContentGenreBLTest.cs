using NSubstitute;
using System.Collections.Generic;
using TVShows.DAL;
using TVShows.Domain;
using Xunit;


namespace TVShows.BL.Tests;

public class ContentGenreBLTest
{
    private ContentGenreBL _contentGenreBL;
    private IContentGenreRepository _contentGenreRepository = Substitute.For<IContentGenreRepository>();

    [Fact]
    public void GetAll_ReturnsCorrectData()
    {
        //arrange

        var s = new List<ContentGenre>
        {
            new ContentGenre
            {
                ContentGenreID = 1,
                GenreID = 1,
                ContentID = 1
            },

            new ContentGenre
            {
                ContentGenreID = 1,
                GenreID = 2,
                ContentID = 1
            }
        };

        _contentGenreRepository.GetAll().Returns(s);
        _contentGenreBL = new ContentGenreBL(_contentGenreRepository);

        //act
        var result = _contentGenreBL.GetAll();

        //assert
        Assert.Equal(1, result[0].ContentGenreID);
        Assert.Equal(2, result[1].GenreID);
        Assert.Equal(2, result.Count);
    }


}