using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto postCreationDto);
    Task<Post?> GetByIdAsync(int id);
    /*Task<IEnumerable<Post>> GetAsync(string? subForm);
    Task DeleteAsync(int id);*/
}