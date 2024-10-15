using System;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public required string UserName { get; set; } // Логин
    public string? Name { get; set; } // Имя
    public string? Surname { get; set; } // Фамилия
    public string? Role { get; set; }  // Роль
    public required string Email { get; set; } // Электронная почта

    public string? Headline { get; set; } // Заголовок

    public string? TwitterLink { get; set; }
    public string? LinkedInLink { get; set; }
    public string? Facebook { get; set; }
    public string? YoutubeLink { get; set; } // Исправьте опечатку "YuotubeLink" на "YoutubeLink"

    public string? Description { get; set; } // Описание
    public string? PhoneNumber { get; set; } // Номер телефона
    public DateTime? DateOfBirth { get; set; } // Дата рождения
    public required byte[] PasswordHash { get; set; } // Хеш пароля
    public required byte[] PasswordSalt { get; set; }
}
