using System;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; } // Логін
    public string Name { get; set; } // Ім'я
    public string Surname { get; set; } // Прізвище 
    public string Role { get; set; }  // Роль
    public string Email { get; set; } // Електронна пошта

    public string Headline { get; set; } // Адреса

    public string TwitterLink { get; set; }
    public string LinkedInLink { get; set; }
    public string Facebook { get; set; }
    public string YuotubeLink { get; set; }



    public string Description { get; set; } // Опис
    public string PhoneNumber { get; set; } // Номер телефону
    public DateTime DateOfBirth { get; set; } // Дата народження
    public required byte[] PasswordHash { get; set; } // Хеш пароля
    public required byte[] PasswordSalt { get; set; }
}
