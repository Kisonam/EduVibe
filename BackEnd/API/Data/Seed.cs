using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;

namespace API.Data;

public class Seed
{
    public static async Task SeedUsers(DataContext context)
    {
        if (context.Users.Any()) return;

        // Читання даних з файлу JSON
        var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

        // Налаштування десеріалізації з кастомним конвертером для DateOnly
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new DateOnlyJsonConverter() }  // Додаємо кастомний конвертер для DateOnly
        };

        // Десеріалізація користувачів з JSON
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

        if (users == null) return;

        foreach (var user in users)
        {
            // Генерація хешу і солі для пароля
            using var hmac = new HMACSHA512();
            user.UserName = user.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));  // Використовуємо стандартний пароль
            user.PasswordSalt = hmac.Key;

            // Додавання фотографій користувача
            foreach (var photo in user.Photos)
            {
                photo.AppUserId = user.Id;  // Зв'язок з користувачем
            }

            // Додавання користувача до контексту
            context.Users.Add(user);
        }

        // Збереження змін у базі
        await context.SaveChangesAsync();
    }


}
