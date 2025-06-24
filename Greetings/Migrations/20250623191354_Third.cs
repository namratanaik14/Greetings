using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Greetings.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Greetings",
                columns: new[] { "Id", "CreatedAt", "GreetingText", "Name" },
                values: new object[] { 1, new DateTime(2025, 6, 23, 19, 13, 53, 744, DateTimeKind.Utc).AddTicks(6930), "Hello, World", "World" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Greetings",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
