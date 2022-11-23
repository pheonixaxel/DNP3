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
            LoadDataPosts();
            return dataContainer!.Post;
        }
    }

    public ICollection<User> Users
    {
        get
        {
            LoadDataUsers();
            return dataContainer!.Users;
        }
    }

    /*public ICollection<SubPost> SubPosts
    {
        get
        {
            LoadData();
            return dataContainer!.SubPosts;
        }
    }*/
    private void LoadDataUsers()
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
            };
            return;
        }

        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    private void LoadDataPosts()
    {
        if (dataContainer != null)
        {
            return;
        }

        if (!File.Exists("postData.json"))
        {
            dataContainer = new()
            {
                Post = new List<Post>()
            };
            return;
        }

        string content = File.ReadAllText("postData.json");
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChangesUser()
    {
        string content = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions()
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, content);
        dataContainer = null;
    }

    public void SaveChangesPost()
    {
        string content = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions()
        {
            WriteIndented = true
        });

        File.WriteAllText("postData.json", content);
        dataContainer = null;
    }
}