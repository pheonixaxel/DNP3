using System.Security.Claims;
using Shared.Models;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<User> GetUser(string username, string password);
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
    
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    public Task RegisterAsync(User user);
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}