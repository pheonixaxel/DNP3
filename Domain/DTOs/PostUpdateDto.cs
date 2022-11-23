namespace Domain.DTOs;

public class PostUpdateDto
{
    public PostUpdateDto(int id)
    {
        
        Id = id;
        
    }

    public bool? IsCompleted { get; set; }
    public int? OwnerId { get;  set; }
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}