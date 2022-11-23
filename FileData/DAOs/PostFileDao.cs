using Application.DaoInterfaces;
using Domain;
using FileData;
using Shared.DTOs;
using Shared.Models;

namespace FileDataAccess.DAOs;

public class PostFileDao : IPostDao
{
    public readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(p => p.Id);
            id++;
        }

        post.Id = id;

        context.Posts.Add(post);
        context.SaveChangesPost();

        return Task.FromResult(post);
    }
    

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(p => p.Id == id);  
        return Task.FromResult(existing);
        
    }

    public Task<User?> GetByIdAsyncPost(int id)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.Id == id
        );
        return Task.FromResult(existing);
    }

    public Task DeleteAsync(int id)
    {
        foreach (var post in context.Posts)
        {
            if (post.Id == id)
            {
                context.Posts.Remove(post);
                context.SaveChangesPost();
                break;
            }
        }

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Post updated)
    {
        foreach (var post in context.Posts)
        {
            if (post.Id == updated.Id)
            {
                context.Posts.Remove(post);
                context.Posts.Add(updated);
                context.SaveChangesPost();
                break;
            }
        }

        return Task.CompletedTask;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();


        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            result = result.Where(p =>
                p.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParameters.UserId != null)
        {
            result = result.Where(p => p.Owner.Id == searchParameters.UserId);
        }

        if (!string.IsNullOrEmpty(searchParameters.UserName))
        {
            result = context.Posts.Where(p =>
                p.Owner.UserName.Equals(searchParameters.UserName, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParameters.completedStatus != null)
        {
            result = result.Where(p => p.IsCompleted == searchParameters.completedStatus);
        }

        return Task.FromResult(result);
    }
}