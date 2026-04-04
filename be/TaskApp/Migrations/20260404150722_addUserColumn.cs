using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApp.Migrations
{
    /// <inheritdoc />
    public partial class addUserColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 4, 22, 7, 20, 319, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 4, 22, 7, 20, 319, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 4, 22, 7, 20, 319, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 4, 22, 7, 20, 319, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 4, 22, 7, 20, 319, DateTimeKind.Local).AddTicks(7494));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 5, 46, 57, 491, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 5, 46, 57, 491, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 5, 46, 57, 491, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 5, 46, 57, 491, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 5, 46, 57, 491, DateTimeKind.Local).AddTicks(5663));
        }
    }
}
