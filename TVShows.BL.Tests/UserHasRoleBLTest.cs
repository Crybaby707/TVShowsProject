using NSubstitute;
using System.Collections.Generic;
using TVShows.DAL;
using TVShows.Domain;
using Xunit;


namespace TVShows.BL.Tests;

public class UserHasRoleBLTest
{
    private UserHasRoleBL _userHasRoleBL;
    private IUserHasRoleRepository _userHasRoleRepository = Substitute.For<IUserHasRoleRepository>();

    [Fact]
    public void GetAll_ReturnsCorrectData()
    {
        //arrange

        var s = new List<UserHasRole>
        {
            new UserHasRole
            {
                
                UserRoleID = 1,
                UserID = 1,
                RoleID = 1
            },

            new UserHasRole
            {
                UserRoleID = 2,
                UserID = 2,
                RoleID = 2

            }
        };

        _userHasRoleRepository.GetAll().Returns(s);
        _userHasRoleBL = new UserHasRoleBL(_userHasRoleRepository);

        //act
        var result = _userHasRoleBL.GetAll();

        //assert
        Assert.Equal(1, result[0].UserRoleID);
        Assert.Equal(2, result[1].UserID);
        Assert.NotEqual(result[0].UserRoleID, result[1].UserRoleID);
        Assert.NotEqual(result[0].UserID, result[1].UserID);
        Assert.Equal(2, result.Count);
    }


}