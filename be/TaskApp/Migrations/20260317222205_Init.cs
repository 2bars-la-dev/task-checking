using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTask", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TodoTask",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "Name", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3146), new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Study controllers, routing, middleware", "Learn ASP.NET Core", 1, new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3165) },
                    { 2, new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3166), new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Work with DbContext and migrations", "Practice EF Core", 0, new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3168) },
                    { 3, new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3169), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create CRUD endpoints", "Build Task API", 0, new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3171) },
                    { 4, new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3173), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resolve API errors", "Fix bugs", 1, new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3174) },
                    { 5, new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3174), new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Document API endpoints", "Write docs", 2, new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3176) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoTask");
        }
    }
}
