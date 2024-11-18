using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class UpdateYoutubeLinkColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Добавляем новый столбец YoutubeLink
            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "Users",
                type: "TEXT",
                nullable: true);

            // Копируем данные из YuotubeLink в YoutubeLink
            migrationBuilder.Sql(
                @"UPDATE Users SET YoutubeLink = YuotubeLink;");

            // Удаляем столбец YuotubeLink
            // Поскольку SQLite не поддерживает удаление столбцов напрямую,
            // мы пересоздадим таблицу без этого столбца
            migrationBuilder.CreateTable(
                name: "Users_temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: true),
                    Headline = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    TwitterLink = table.Column<string>(type: "TEXT", nullable: true),
                    LinkedInLink = table.Column<string>(type: "TEXT", nullable: true),
                    Facebook = table.Column<string>(type: "TEXT", nullable: true),
                    YoutubeLink = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_temp", x => x.Id);
                });

            // Копируем данные из старой таблицы в новую
            migrationBuilder.Sql(
                @"INSERT INTO Users_temp (Id, UserName, Email, Name, Surname, Role, Headline, Description, PhoneNumber, DateOfBirth, PasswordHash, PasswordSalt, TwitterLink, LinkedInLink, Facebook, YoutubeLink)
                  SELECT Id, UserName, Email, Name, Surname, Role, Headline, Description, PhoneNumber, DateOfBirth, PasswordHash, PasswordSalt, TwitterLink, LinkedInLink, Facebook, YoutubeLink FROM Users;");

            // Удаляем старую таблицу
            migrationBuilder.DropTable(name: "Users");

            // Переименовываем новую таблицу в Users
            migrationBuilder.RenameTable(name: "Users_temp", newName: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Создаем столбец YuotubeLink
            migrationBuilder.AddColumn<string>(
                name: "YuotubeLink",
                table: "Users",
                type: "TEXT",
                nullable: true);

            // Копируем данные из YoutubeLink обратно в YuotubeLink
            migrationBuilder.Sql(
                @"UPDATE Users SET YuotubeLink = YoutubeLink;");

            // Создаем временную таблицу без столбца YoutubeLink
            migrationBuilder.CreateTable(
                name: "Users_temp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: true),
                    Headline = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    TwitterLink = table.Column<string>(type: "TEXT", nullable: true),
                    LinkedInLink = table.Column<string>(type: "TEXT", nullable: true),
                    Facebook = table.Column<string>(type: "TEXT", nullable: true),
                    YuotubeLink = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_temp", x => x.Id);
                });

            // Копируем данные из Users в Users_temp
            migrationBuilder.Sql(
                @"INSERT INTO Users_temp (Id, UserName, Email, Name, Surname, Role, Headline, Description, PhoneNumber, DateOfBirth, PasswordHash, PasswordSalt, TwitterLink, LinkedInLink, Facebook, YuotubeLink)
                  SELECT Id, UserName, Email, Name, Surname, Role, Headline, Description, PhoneNumber, DateOfBirth, PasswordHash, PasswordSalt, TwitterLink, LinkedInLink, Facebook, YuotubeLink FROM Users;");

            // Удаляем таблицу Users
            migrationBuilder.DropTable(name: "Users");

            // Переименовываем Users_temp обратно в Users
            migrationBuilder.RenameTable(name: "Users_temp", newName: "Users");
        }
    }
}
