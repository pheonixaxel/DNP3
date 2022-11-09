namespace Shared.Models;

public class SubPost
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public User Owner { get; }
    public ICollection<Post> Posts { get; set; }

    
}