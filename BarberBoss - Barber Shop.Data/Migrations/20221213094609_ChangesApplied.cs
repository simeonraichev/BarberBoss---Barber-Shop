using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberBossBarberShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangesApplied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSalonRatedByTheUser",
                table: "Appointments",
                newName: "IsBarberShopRatedByTheUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBarberShopRatedByTheUser",
                table: "Appointments",
                newName: "IsSalonRatedByTheUser");
        }
    }
}
