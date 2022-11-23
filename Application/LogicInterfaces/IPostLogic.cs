using Domain.DTOs;
using Shared.Models;
using Shared.DTOs;


using Shared.Models;

namespace Application.Logic;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto postCreationDto);
    Task<Post?> GetByIdAsync(int id);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParametersDto);
    Task UpdateAsync(PostUpdateDto post);
}