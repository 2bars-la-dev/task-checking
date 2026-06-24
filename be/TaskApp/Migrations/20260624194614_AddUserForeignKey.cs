using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUserForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TodoTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TodoTasks_UserId",
                table: "TodoTasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Users_UserId",
                table: "TodoTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Users_UserId",
                table: "TodoTasks");

            migrationBuilder.DropIndex(
                name: "IX_TodoTasks_UserId",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "TodoTasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 4, 22, 7, 20, 319, DateTimeKind.Local).AddTicks(7472), new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Study controllers, routing, middleware", "Learn ASP.NET Core", 1, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2026, 4, 4, 22, 7, 20, 319, DateTimeKind.Local).AddTicks(7489), new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Work with DbContext and migrations", "Practice EF Core", 0, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2026, 4, 4, 22, 7, 20, 319, DateTimeKind.Local).AddTicks(7491), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create CRUD endpoints", "Build Task API", 0, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2026, 4, 4, 22, 7, 20, 319, DateTimeKind.Local).AddTicks(7493), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resolve API errors", "Fix bugs", 1, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2026, 4, 4, 22, 7, 20, 319, DateTimeKind.Local).AddTicks(7494), new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Document API endpoints", "Write docs", 2, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
