using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberBossBarberShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class TownSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_MyApplicationUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_MyApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_MyApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_MyApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_MyApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_MyApplicationUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "MyApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "MyApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "MyApplicationUserId",
                table: "AspNetUserClaims");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyApplicationUserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyApplicationUserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyApplicationUserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_MyApplicationUserId",
                table: "AspNetUserRoles",
                column: "MyApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_MyApplicationUserId",
                table: "AspNetUserLogins",
                column: "MyApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_MyApplicationUserId",
                table: "AspNetUserClaims",
                column: "MyApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_MyApplicationUserId",
                table: "AspNetUserClaims",
                column: "MyApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_MyApplicationUserId",
                table: "AspNetUserLogins",
                column: "MyApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_MyApplicationUserId",
                table: "AspNetUserRoles",
                column: "MyApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
