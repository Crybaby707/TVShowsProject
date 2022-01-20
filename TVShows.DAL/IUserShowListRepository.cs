using TVShows.Domain;

namespace TVShows.DAL;

public interface IUserShowListRepository
{
    IList<UserShowList> GetAll();

    UserShowList AddUserShowList(UserShowList userShowList);

    UserShowList UpdateUserShowList(UserShowList userShowList);

    bool DeleteUserShowList(int userShowListId);

    UserShowList GetUserShowListById(int userShowListId);
}

