using Shared.Models;

namespace Shared.DTOs;

public class PostCreationDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int OwnerId { get; set; }
    public int PostId { get; set; }
    
}