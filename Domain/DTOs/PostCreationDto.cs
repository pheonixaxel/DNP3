using Shared.Models;

namespace Shared.DTOs;

public class PostCreationDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public User OwnerId { get; set; }
    
}