using Shared.DTOs;
using Shared.Models;

namespace Application.IUserDao;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User> GetByUsernameAsync(string userName);
    Task<IEnumerable<User>> GetAsync();
    Task<User?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task UpdateAsync(User updated);
}