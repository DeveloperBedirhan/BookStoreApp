using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d50a4d3-5cb5-4286-9944-917d63bb7ea5", null, "Admin", "ADMIN" },
                    { "926d6236-50ed-46ad-8aff-45e61b8cc58f", null, "User", "USER" },
                    { "ea7103cd-2df8-44ca-a5f9-5bacf25c5cde", null, "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d50a4d3-5cb5-4286-9944-917d63bb7ea5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "926d6236-50ed-46ad-8aff-45e61b8cc58f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea7103cd-2df8-44ca-a5f9-5bacf25c5cde");
        }
    }
}
