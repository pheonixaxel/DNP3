using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/posts",dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
        else
        {
            return await response.Content.ReadFromJsonAsync<Post>();
        }
    }
    

    public async Task<ICollection<Post>> GetAsync(string title, string content, int ownerId, int postId)
    {
        HttpResponseMessage responseMessage = await client.GetAsync("/posts");
        string messageContent = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(messageContent);
        }
        
        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(messageContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return posts;
    }
}