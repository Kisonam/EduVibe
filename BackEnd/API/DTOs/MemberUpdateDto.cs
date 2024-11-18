using System;

namespace API.DTOs;

public class MemberUpdateDto
{
    public string? Email { get; set; } 
    public string? Headline { get; set; }
    public string? TwitterLink { get; set; }
    public string? LinkedInLink { get; set; }
    public string? Facebook { get; set; }
    public string? YoutubeLink { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }

}
