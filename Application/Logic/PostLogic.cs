using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;


namespace Application.Logic;

public class PostLogic : IPostLogic

{
    private readonly IPostDao postDao;
    private readonly IUserDao.IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao.IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto postToCreate)
    {
        User? user = await userDao.GetByIdAsync(postToCreate.OwnerId);
        if (user == null)
        {
            throw new ArgumentException("User does not exist");
        }

        Post post = new Post
        {
            Title = postToCreate.Title,
            Content = postToCreate.Content,
            OwnerId = user
        };
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(string? subPost)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}