using System.Text.Json;
using Shared.Models;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer? dataContainer;

    public ICollection<Post> Posts
    {
        get
        {
            LoadData();
            return dataContainer!.Posts;
        }
    }
    
    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return dataContainer!.Users;
        }
    }

    public ICollection<SubPost> SubPosts
    {
        get
        {
            LoadData();
            return dataContainer!.SubPosts;
        }
    }
    private void LoadData()
    {
        if (dataContainer != null)
        {
            return;
        }

        if (!File.Exists(filePath))
        {
            dataContainer = new()
            {
                Users = new List<User>(),
                Posts = new List<Post>(),
                SubPosts = new List<SubPost>()
            };
            return;
        }
        
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }
    
    public void SaveChanges()
    {
        string content = JsonSerializer.Serialize(dataContainer);
        File.WriteAllText(filePath, content);
        dataContainer = null;
    }
}