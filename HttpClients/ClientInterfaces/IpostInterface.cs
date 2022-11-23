using Shared.Models;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces;


public interface IpostInterface
{
    Task<Post> CreateAsync(PostCreationDto dto);
    
    Task<ICollection<Post>> GetAsync(
        string? userName, 
        int? userId,
        string? titleContains,
        bool? completedStatus
    );
    
    Task<IEnumerable<Post>> GetPosts(string? userName, int? userId, string? titleContains, bool? completedStatus);
}