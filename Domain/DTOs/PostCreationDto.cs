using Shared.Models;

namespace Shared.DTOs;

public class PostCreationDto
{
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }
    
    public string Description { get; }
    public bool IsCompleted { get; }
    

    public PostCreationDto(int id, string title, string description, bool isCompleted)
    {
        Id = id;
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
    }
    public PostCreationDto(int selectedUserId, string postTitle, string postDesc)
    {
        Id = selectedUserId;
        Title = postTitle;
        Description = postDesc;
    }
}