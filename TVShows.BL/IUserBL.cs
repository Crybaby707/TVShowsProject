﻿using TVShows.Domain;

namespace TVShows.BL;

public interface IUserBL
{
    IList<User> GetAll();

    User CreateUser(User users);

    bool DeleteUser(int userId);

    User GetUserById(int userId);

}

