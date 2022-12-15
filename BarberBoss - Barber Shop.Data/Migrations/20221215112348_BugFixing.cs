using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberBossBarberShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class BugFixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_BarberShopsServices_BarberShopServiceBarberShopId_BarberShopServiceServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShops_BarberServices_BarberServiceId",
                table: "BarberShops");

            migrationBuilder.AlterColumn<bool>(
                name: "Available",
                table: "BarberShopsServices",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "BarberServiceId",
                table: "BarberShops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BarberShopServiceServiceId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BarberShopServiceBarberShopId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_BarberShopsServices_BarberShopServiceBarberShopId_BarberShopServiceServiceId",
                table: "Appointments",
                columns: new[] { "BarberShopServiceBarberShopId", "BarberShopServiceServiceId" },
                principalTable: "BarberShopsServices",
                principalColumns: new[] { "BarberShopId", "ServiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShops_BarberServices_BarberServiceId",
                table: "BarberShops",
                column: "BarberServiceId",
                principalTable: "BarberServices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_BarberShopsServices_BarberShopServiceBarberShopId_BarberShopServiceServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShops_BarberServices_BarberServiceId",
                table: "BarberShops");

            migrationBuilder.AlterColumn<bool>(
                name: "Available",
                table: "BarberShopsServices",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BarberServiceId",
                table: "BarberShops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BarberShopServiceServiceId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BarberShopServiceBarberShopId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_BarberShopsServices_BarberShopServiceBarberShopId_BarberShopServiceServiceId",
                table: "Appointments",
                columns: new[] { "BarberShopServiceBarberShopId", "BarberShopServiceServiceId" },
                principalTable: "BarberShopsServices",
                principalColumns: new[] { "BarberShopId", "ServiceId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShops_BarberServices_BarberServiceId",
                table: "BarberShops",
                column: "BarberServiceId",
                principalTable: "BarberServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
