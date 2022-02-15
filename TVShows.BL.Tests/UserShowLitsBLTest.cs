using NSubstitute;
using System.Collections.Generic;
using TVShows.DAL;
using TVShows.Domain;
using Xunit;


namespace TVShows.BL.Tests;

public class UserShowListBLTest
{
    private UserShowListBL _userShowListBL;
    private IUserShowListRepository _userShowListRepository = Substitute.For<IUserShowListRepository>();

    [Fact]
    public void GetAll_ReturnsCorrectData()
    {
        //arrange

        var s = new List<UserShowList>
        {
            new UserShowList
            {
                UserShowListID = 1,
                ContentID = 1,
                UserId = 3,
                ListsCategory = Domain.Enums.ListsCategoryEnum.Favorites,
                
            },

            new UserShowList
            {

                UserShowListID = 2,
                ContentID = 1,
                UserId = 4,
                ListsCategory = Domain.Enums.ListsCategoryEnum.WatchNext,

            }
        };

        _userShowListRepository.GetAll().Returns(s);
        _userShowListBL = new UserShowListBL(_userShowListRepository);

        //act
        var result = _userShowListBL.GetAll();

        //assert
        Assert.Equal(1, result[0].UserShowListID);
        Assert.Equal(4, result[1].UserId);
        Assert.NotEqual(result[0].UserShowListID, result[1].UserShowListID);
        Assert.NotEqual(result[0].ListsCategory, result[1].ListsCategory);
        Assert.Equal(2, result.Count);
    }


}