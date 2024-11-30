using System.Text.Json.Serialization;
using API.Extensions;
using Microsoft.AspNetCore.Identity;

namespace API.Entities;
public class AppUser : IdentityUser<int>
{
    public string? Name { get; set; } 
    public string? Surname { get; set; } 
    // [JsonPropertyName("email")]
    // public required string Email { get; set; } 
    public string? Headline { get; set; }
    public string? TwitterLink { get; set; }
    public string? LinkedInLink { get; set; }
    public string? Facebook { get; set; }
    public string? YoutubeLink { get; set; }
    public string? Description { get; set; } 
    // public string? PhoneNumber { get; set; }
    public DateOnly DateOfBirth { get; set; } 
    public ICollection<Photo>? Photos { get; set; }
    public ICollection<AppUserRole> UserRoles { get; set; } = [];
}

