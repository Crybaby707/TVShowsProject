﻿using TVShows.Domain;

namespace TVShows.BL;

public interface IUserShowListBL
{
    IList<UserShowList> GetAll();

    UserShowList AddUserShowList(UserShowList userShowList);

    bool DeleteUserShowList(int userShowList);

    UserShowList GetUserShowListById(int userShowList);
}
