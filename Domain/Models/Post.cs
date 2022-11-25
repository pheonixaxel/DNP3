using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    public string Title { get; private set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public User Owner { get; private set; }
    
    /*public Post()
    {
        Id = 0;
        Title = string.Empty;
        Content = string.Empty;
        Created = DateTime.Now;
        Updated = null;
        Owner = null;
    }*/

    public Post(string title, string content, User user)
    {
        Title = title;
        Content = content;
        Owner = user;
    }
    
    private Post(){}
}