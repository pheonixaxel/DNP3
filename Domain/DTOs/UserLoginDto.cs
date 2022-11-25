﻿namespace Shared.DTOs;

public class UserLoginDto
{
    public string UserName { get; init; }
    public string Password { get; init; }
    
    public UserLoginDto(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}