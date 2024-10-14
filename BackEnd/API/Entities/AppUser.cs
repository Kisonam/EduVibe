using System;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; } // Логін
    public string Name { get; set; } // Ім'я
    public string Surname { get; set; } // Прізвище 
    public string Role { get; set; } = "Customer"; // Роль
    public string Email { get; set; } // Електронна пошта
    public DateTime DateOfBirth { get; set; } // Дата народження
    public required byte[] PasswordHash { get; set; } // Хеш пароля
    public required byte[] PasswordSalt { get; set; }
}
