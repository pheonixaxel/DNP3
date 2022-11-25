using Application.IUserDao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DTOs;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly ForumContext context;
    
    public UserEfcDao(ForumContext context)
    {
        this.context = context;
    }
    
    public async Task<User> CreateAsync(User user)
    {
        try
        {
            EntityEntry<User> newUser = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return newUser.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e + " " + e.StackTrace);
            throw;
        }
    }

    public async Task<User> GetByUsernameAsync(string userName)
    {
        try
        {
            return await context.Users.FirstOrDefaultAsync(user => user.UserName.ToLower().Equals(userName.ToLower()));
        }
        catch(Exception e)
        {
            Console.WriteLine(e + " " + e.StackTrace);
            throw;
        }
    }


    public Task<IEnumerable<User>> GetAsync()
    {
        throw new NotImplementedException();
    }
    
    public async Task<User?> GetByIdAsync(int id)
    {
        return await context.Users.FirstAsync(user => user.Id.Equals(id));
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