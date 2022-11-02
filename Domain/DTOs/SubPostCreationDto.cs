using Shared.Models;

namespace Shared.DTOs;

public class SubPostCreationDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public User OwnerId { get; set; }
}