namespace Shared.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public User OwnerId { get; set; }

    public Post(string title, string content, User ownerId)
    {
        Title = title;
        Content = content;
        OwnerId = ownerId;
    }
}