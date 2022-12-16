using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberBossBarberShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingBuxFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "66060726-5520-4b59-96d8-9c9c1b9c43b6", "seededAdminb8633e2d-a33b-45e6-8329-1958b3252bbd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "66060726-5520-4b59-96d8-9c9c1b9c43b6", "seededAdminb8633e2d-a33b-45e6-8329-1958b3252bbd" });
        }
    }
}
