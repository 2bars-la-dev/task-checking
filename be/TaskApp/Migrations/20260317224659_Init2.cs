using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApp.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoTask",
                table: "TodoTask");

            migrationBuilder.RenameTable(
                name: "TodoTask",
                newName: "TodoTasks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoTasks",
                table: "TodoTasks",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 5, 46, 57, 491, DateTimeKind.Local).AddTicks(5640), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 5, 46, 57, 491, DateTimeKind.Local).AddTicks(5657), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 5, 46, 57, 491, DateTimeKind.Local).AddTicks(5659), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 5, 46, 57, 491, DateTimeKind.Local).AddTicks(5661), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 5, 46, 57, 491, DateTimeKind.Local).AddTicks(5663), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoTasks",
                table: "TodoTasks");

            migrationBuilder.RenameTable(
                name: "TodoTasks",
                newName: "TodoTask");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoTask",
                table: "TodoTask",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "TodoTask",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3146), new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3165) });

            migrationBuilder.UpdateData(
                table: "TodoTask",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3166), new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3168) });

            migrationBuilder.UpdateData(
                table: "TodoTask",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3169), new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3171) });

            migrationBuilder.UpdateData(
                table: "TodoTask",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3173), new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3174) });

            migrationBuilder.UpdateData(
                table: "TodoTask",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3174), new DateTime(2026, 3, 18, 5, 22, 3, 496, DateTimeKind.Local).AddTicks(3176) });
        }
    }
}
