using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic

{
    private readonly IPostDao postDao;
    private readonly IUserDao.IUserDao userDao;

    public PostLogic(IPostDao postDao , IUserDao.IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }
    

    public Task<IEnumerable<Post>> GetCommentsAsync(Post parentPost)
    {
        throw new NotImplementedException();
    }

    public Task<Post> CreateAsync(PostCreationDto postCreationDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAsync(string? subForm)
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