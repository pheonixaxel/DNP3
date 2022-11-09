using System.Security.Cryptography;
using System.Text;
using Shared.Models;

namespace Shared.DTOs;

public class UserCreationDto
{
    public string UserName { get; init; }
    public string Password { get; init; }

    public UserCreationDto(string userName, string password)
    {
        UserName = userName;
       Password = password;
    }
    
    
}