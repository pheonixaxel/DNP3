using System.Security.Cryptography;
using System.Text;

namespace Shared.DTOs;

public class UserCreationDto
{
    public string UserName { get;}
    public string Password { get;}

    public UserCreationDto(string userName, string password)
    {
        UserName = userName;
        string hashedPassword = string.Empty;
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
        Password = hashedPassword;
    }
    
}