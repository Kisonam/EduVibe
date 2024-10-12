using System;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    // public string Role { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
}
