
namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public string? Name { get; set; } 
    public string? Surname { get; set; } 
    public string? Role { get; set; }
    public required string Email { get; set; } 
    public string? Headline { get; set; }
    public string? TwitterLink { get; set; }
    public string? LinkedInLink { get; set; }
    public string? Facebook { get; set; }
    public string? YoutubeLink { get; set; }
    public string? Description { get; set; } 
    public string? PhoneNumber { get; set; } 
    public DateTime? DateOfBirth { get; set; } 
    public required byte[] PasswordHash { get; set; } 
    public required byte[] PasswordSalt { get; set; }
}
