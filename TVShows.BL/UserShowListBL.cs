using TVShows.DAL;
using TVShows.Domain;

namespace TVShows.BL;
public class UserShowListBL : IUserShowListBL
{
    private readonly IUserShowListRepository _userShowListRepository;

    public UserShowListBL(IUserShowListRepository userShowListRepository)
    {
        _userShowListRepository = userShowListRepository;
    }

    public UserShowList AddUserShowList(UserShowList userShowList)
    {
        return _userShowListRepository.AddUserShowList(userShowList);
    }

    public bool DeleteUserShowList(int userShowList)
    {
        return _userShowListRepository.DeleteUserShowList(userShowList);
    }

    public IList<UserShowList> GetAll()
    {
        return _userShowListRepository.GetAll();
    }

    public UserShowList GetUserShowListById(int userShowList)
    {
        return _userShowListRepository.GetUserShowListById(userShowList);
    }

    public UserShowList UpdateUserShowList(UserShowList userShowList)
    {
        return _userShowListRepository.UpdateUserShowList(userShowList);
    }
}

