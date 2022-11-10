using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<Post> CreateAsync(PostCreationDto postCreationDto);
    Task<ICollection<Post>> GetAsync(
        string title, 
        string content,
        int ownerId, 
        int postId
    );
}