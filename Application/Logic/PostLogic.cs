using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
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
        User? user = await userDao.GetByIdAsync(postToCreate.Id);
        if (user == null)
        {
            throw new ArgumentException("User does not exist");
        }

        ValidatePost(postToCreate);
        Post post = new Post(user, postToCreate.Title,postToCreate.Description,postToCreate.IsCompleted);
        user.Posts.Add(post);
        user.Posts = new List<Post>();
        Post created = await postDao.CreateAsync(post);
        return created;
    }
    
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParametersDto)
    {
        return postDao.GetAsync(searchPostParametersDto);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(PostUpdateDto post)
    {
        Post? existing = await postDao.GetByIdAsync(post.Id);
        if (existing == null)
        {
            throw new Exception($"Post with ID {post.Id} not found!");
        }

        User? user = null;
        if (post.OwnerId != null)
        {
            user = await userDao.GetByIdAsync((int)post.OwnerId);
            if (user == null)
            {
                throw new Exception($"User with id {post.OwnerId} was not found.");
            }
        }

        User userToUse = user ?? existing.Owner;
        string titleToUse = post.Title ?? existing.Title;
        string descToUse = post.Description ?? existing.Description;
        bool isCompleted = post.IsCompleted ?? existing.IsCompleted;

        Post updated = new(userToUse, titleToUse, descToUse, isCompleted)
        {
            Id = existing.Id
        };
        ValidatePost(updated);
    }
    private void ValidatePost(Post post)
    {
        if (string.IsNullOrEmpty(post.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(post.Description)) throw new Exception("Description cannot be empty.");

    }
    private void ValidatePost(PostCreationDto post)
    {
        if (string.IsNullOrEmpty(post.Title)) throw new Exception("Title cannot be empty.");
        if (string.IsNullOrEmpty(post.Description)) throw new Exception("Description cannot be empty.");
    }
}