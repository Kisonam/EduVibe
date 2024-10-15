using API.Interfaces; // Интерфейс для токенов
using API.Services;   // Реализация TokenService
using API.Data;       // Контекст базы данных DataContext
using Microsoft.AspNetCore.Authentication.JwtBearer; // JWT Bearer аутентификация
using Microsoft.EntityFrameworkCore; // Entity Framework Core
using Microsoft.IdentityModel.Tokens; // Для работы с валидацией токенов и ключами (обратите внимание на 'Tokens')
using Microsoft.OpenApi.Models; // Для Swagger
using System.Text; // Для кодировки

var builder = WebApplication.CreateBuilder(args);

// Добавление контекста базы данных для работы с SQLite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавление сервисов в контейнер DI
builder.Services.AddControllers();
builder.Services.AddScoped<ITokenService, TokenService>(); // Регистрация TokenService

// Настройка CORS для Angular на http://localhost:4200
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()  // Включить передачу куков/авторизационных данных
              .WithOrigins("http://localhost:4200"); // Укажите URL фронтенда
    });
});

// Добавление Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// Получаем TokenKey из конфигурации
var tokenKey = builder.Configuration["TokenKey"];
if (string.IsNullOrEmpty(tokenKey))
{
    throw new ArgumentNullException(nameof(tokenKey), "TokenKey must be set in configuration.");
}

// Создаем SymmetricSecurityKey для JWT-аутентификации
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

// Добавление аутентификации с JWT Bearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

var app = builder.Build();

// Включаем Swagger только в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Swagger доступен по корневому пути
    });
}

// Настройка HTTP pipeline
app.UseCors("CorsPolicy"); // Применяем CORS-политику
app.UseAuthentication();    // Аутентификация с JWT
app.UseAuthorization();     // Авторизация

app.MapControllers();

app.Run();
