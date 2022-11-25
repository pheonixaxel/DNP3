using System.Text.Json;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace RESTClient.HttpCalls;

public class UserHttpService : IUserLogic
{
    public async Task<User> CreateAsync(UserCreationDto userToCreate)
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Post, "/user", userToCreate);
            User userLocal = JsonSerializer.Deserialize<User>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            return userLocal;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<User> GetByIdAsync(int id)
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Get, "/user/" + id);
            User user = JsonSerializer.Deserialize<User>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}