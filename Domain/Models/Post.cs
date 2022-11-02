namespace Shared.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public string AuthorId { get; set; }
    public ApplicationUser Author { get; set; }
    public ICollection<Comment> Comments { get; set; }
}