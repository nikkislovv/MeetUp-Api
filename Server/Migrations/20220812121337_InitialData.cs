using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "Name", "Organizer", "Place", "Time" },
                values: new object[,]
                {
                    { new Guid("6cead492-73c4-48cf-9d77-4c3ef35052cb"), "Excursion to the Museum of old cars", "Excursion", "Nikita Kislov", "L.Sapegi 5", new DateTime(2022, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2195fd5f-7453-47d1-9387-3a45042c68a1"), "Сinema evening of scary movies", "Movie Night", "Ivan Filimonov", "R.Slovat 44", new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("568b22ff-d7a2-4e8e-8291-e70219781699"), "Birthday of Nick, 25 years", "Birthday", "Andrey Ivanov", "O.Rydnova 32", new DateTime(2022, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1bdbc616-2a86-4a08-a804-bb8fddc1b6ee"), "Fitness training for beginners", "Fitness Training", "Alex Ivanov", "Pavlov Park", new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("1bdbc616-2a86-4a08-a804-bb8fddc1b6ee"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("2195fd5f-7453-47d1-9387-3a45042c68a1"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("568b22ff-d7a2-4e8e-8291-e70219781699"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6cead492-73c4-48cf-9d77-4c3ef35052cb"));
        }
    }
}
