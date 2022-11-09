/*using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class SubPostLogic : ISubPostLogic
{
    private readonly ISubPostDao SubpostDao;
    private readonly IUserDao.IUserDao userDao;

    public SubPostLogic(ISubPostDao SubpostDao, IUserDao.IUserDao userDao)
    {
        this.SubpostDao = SubpostDao;
        this.userDao = userDao;
    }

    public async Task<SubPost> SubCreateAsync(SubPostCreationDto SubpostToCreate)
    {
        User? user = await userDao.GetByIdAsync(SubpostToCreate.OwnerId);
        if (user == null)
        {
            throw new ArgumentException("User does not exist");
        }
        
        SubPost post = new SubPost
        {
            Id = SubpostToCreate.Id,
            Name = SubpostToCreate.Name,
            Owner = user,
            Posts = new List<Post>()
        };
        SubPost created = await SubpostDao.SubCreateAsync(post, SubPostCreationDto.SubId);
        return created;
    }

    public Task SubGetAsync(string? subPost)
    {
        throw new NotImplementedException();
    }

    public Task SubGetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<SubPostLogic>   DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}*/