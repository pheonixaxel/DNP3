using Application.IUserDao;
using Shared.DTOs;
using Shared.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext context;
    
    public UserFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id) + 1;
        }
        
        user.Id = userId;
        
        context.Users.Add(user);
        context.SaveChangesUser();
        
        return Task.FromResult(user);
    }
    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<User> CreateAsync(UserCreationDto userCreationDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        return Task.FromResult(context.Users.FirstOrDefault(u => u.Id == id));
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User updated)
    {
        throw new NotImplementedException();
    }
}