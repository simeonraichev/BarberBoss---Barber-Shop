using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberBossBarberShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class BarberUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "12ba897f-7ff7-4710-bc86-87455d6dbd03", "seededBarberb8633e2d-a33b-45e6-8329-1958b3252bbd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "12ba897f-7ff7-4710-bc86-87455d6dbd03", "seededBarberb8633e2d-a33b-45e6-8329-1958b3252bbd" });
        }
    }
}
