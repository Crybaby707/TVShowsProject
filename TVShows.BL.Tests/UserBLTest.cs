using NSubstitute;
using System.Collections.Generic;
using TVShows.DAL;
using TVShows.Domain;
using Xunit;


namespace TVShows.BL.Tests;

public class UserBLTest
{
    private UserBL _userBL;
    private IUserRepository _userRepository = Substitute.For<IUserRepository>();

    [Fact]
    public void GetAll_ReturnsCorrectData()
    {
        //arrange

        var s = new List<User>
        {
            new User
            {
                UserID = 1,
                UserName = "John",
                Email = "sitizen36@gmail.com",
                Password = "password"
            },

            new User
            {
                UserID = 2,
                UserName = "Yarik",
                Email= "Yarik@gmail.com",
                Password= "password"
               
            }
        };

        _userRepository.GetAll().Returns(s);
        _userBL = new UserBL(_userRepository);

        //act
        var result = _userBL.GetAll();

        //assert
        Assert.Equal("John", result[0].UserName);
        Assert.Equal(2, result[1].UserID);
        Assert.Equal("password", result[1].Password);
        Assert.Equal("Yarik@gmail.com", result[1].Email);
        Assert.Equal(2, result.Count);
    }


}