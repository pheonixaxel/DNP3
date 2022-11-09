using Shared.Models;
using Shared.DTOs;


using Shared.Models;

namespace Application.Logic;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto postCreationDto);
    Task<IEnumerable<Post>> GetAsync(string? subForm);
    Task<Post?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}