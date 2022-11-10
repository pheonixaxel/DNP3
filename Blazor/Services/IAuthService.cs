using System.Security.Claims;
using Shared.Models;

namespace Blazor.Services;

public interface IAuthService
{
    Task LoginAsync(string userName, string Password);
    Task LogoutAsync();

    Task RegisterAsync(User user);
    /*public Task<ClaimsPrincipal> GetAuthAsync();*/

    Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    Task<ClaimsPrincipal> GetAuthAsync();
}