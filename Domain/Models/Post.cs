namespace Shared.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }
    
    public string Description { get; }
    public bool IsCompleted { get; }
    

    public Post(User owner, string title, string description, bool isCompleted)
    {
        Owner = owner;
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
    }

}