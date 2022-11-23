namespace Shared.DTOs;

public class SearchPostParametersDto
{
    public  string? TitleContains { get; }
    public int? UserId { get; }
    
    public string? UserName { get; }
    public bool? completedStatus { get; }
    
    
    public SearchPostParametersDto(int? UserID, string? UserName, string? titleContains, bool? completedStatus)
    {
        UserId = UserID;
        this.UserName = UserName;
        TitleContains = titleContains;
        this.completedStatus = completedStatus;
    }
}