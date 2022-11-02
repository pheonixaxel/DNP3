﻿using Shared.Models;

namespace Application.IUserDao;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User> GetByUsernameAsync(string userName);
}