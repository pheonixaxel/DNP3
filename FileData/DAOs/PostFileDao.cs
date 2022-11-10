using Application.DaoInterfaces;
using Domain;
using FileData;
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

    public Task<IEnumerable<Post>> GetAsync(string? subForm)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        
        return Task.FromResult(posts);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? toGet = null;
        foreach (var post in context.Posts)
        {
            if (post.Id == id)
            {
                toGet = post;
                break;
            }
        }

        return Task.FromResult(toGet);
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
}