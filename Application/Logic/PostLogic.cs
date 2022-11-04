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
    private void ValidatePost(PostCreationDto post)
    {
        if (post == null)
        {
            throw new ArgumentNullException(nameof(post));
        }
        if (post.Content == null)
        {
            throw new ArgumentNullException(nameof(post.Content));
        }
        if (post.Content.Length > 1000)
        {
            throw new ArgumentException("Post content is too long");
        }
    }

    public async Task<Post> CreateAsync(PostCreationDto postCreationDto)
    {
        User? user = await userDao.GetByIdAsync(postCreationDto.OwnerId);
        if (user == null)
        {
            throw new Exception($"User with id {postCreationDto.OwnerId} does not exist");
        }
        
        ValidatePost(postCreationDto);
        Post post = new Post(postCreationDto.Title, postCreationDto.Content, user);
        Post created = await postDao.CreateAsync(post);

        return created;
    }
    
    public Task<Post?> GetByIdAsync(int id)
    {
        return postDao.GetByIdAsync(id);
    }
    /*public Task<IEnumerable<Post>> GetCommentsAsync(Post parentPost)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAsync(string? subForm)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }*/
}