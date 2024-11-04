using System;
using System.Text.Json.Serialization;
using API.Entities;

namespace API.DTOs;

public class MemberDto
{
   public int Id { get; set; }
    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
    public string? Name { get; set; } 
    public string? Surname { get; set; } 
    [JsonPropertyName("email")]
    public string? Email { get; set; } 
    public int Age { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Headline { get; set; }
    public string? TwitterLink { get; set; }
    public string? LinkedInLink { get; set; }
    public string? Facebook { get; set; }
    public string? YoutubeLink { get; set; }
    public string? Description { get; set; } 
    public string? PhoneNumber { get; set; } 
    public List<PhotoDto> Photos { get; set; }
}
