using System.Security.Cryptography;
using System.Text;
using Shared.Models;

namespace Shared.DTOs;

public class UserCreationDto
{
    public string UserName { get; init; }
    public string Password { get; init; }
    public string Email { get; init; }

    public UserCreationDto(string userName, string password, string email)
    {
        UserName = userName;
        Password = password;
        Email = email;
    }
}