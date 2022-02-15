using NSubstitute;
using System.Collections.Generic;
using TVShows.DAL;
using TVShows.Domain;
using Xunit;


namespace TVShows.BL.Tests;

public class ContentBLTest
{
    private ContentBL _contentBL;
    private IContentRepository _contentRepository = Substitute.For<IContentRepository>();

    [Fact]
    public void GetAll_ReturnsCorrectData()
    {
        //arrange

        var s = new List<Content>
        {
            new Content
            {
                ContentID = 1,
                Title = "Breaking bad",
                Description = "Serial about metafetamin",
                Rate = 5
            },

            new Content
            {
                ContentID = 2,
                Title = "Dexter",
                Description = null
            }
        };

        _contentRepository.GetAll().Returns(s);
        _contentBL = new ContentBL(_contentRepository);

        //act
        var result = _contentBL.GetAll();

        //assert
        Assert.Equal("Breaking bad", result[0].Title);
        Assert.Equal("Serial about metafetamin", result[0].Description);
        Assert.Equal(null, result[1].Description);
        Assert.Equal(2, result[1].ContentID);
        Assert.Equal(2, result.Count);
        Assert.Equal(5, result[0].Rate);
    }


}