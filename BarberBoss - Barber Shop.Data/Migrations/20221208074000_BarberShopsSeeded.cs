using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberBoss____Barber_Shop.Data.Migrations
{
    public partial class BarberShopsSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_UserId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_BarberShop_BarberShopId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_BarberShopsService_BarberShopServiceId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Service_ServiceId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_MyApplicationUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_MyApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_MyApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShop_AspNetUsers_OwnerId",
                table: "BarberShop");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShop_Town_TownId",
                table: "BarberShop");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShopsService_BarberShop_BarberShopId",
                table: "BarberShopsService");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShopsService_Service_ServiceId",
                table: "BarberShopsService");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_MyApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_MyApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_MyApplicationUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Town",
                table: "Town");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberShopsService",
                table: "BarberShopsService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberShop",
                table: "BarberShop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_BarberShopServiceId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "MyApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "MyApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "MyApplicationUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "BarberShopServiceId",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Town",
                newName: "Towns");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "BarberShopsService",
                newName: "BarberShopsServices");

            migrationBuilder.RenameTable(
                name: "BarberShop",
                newName: "BarberShops");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Town_IsDeleted",
                table: "Towns",
                newName: "IX_Towns_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Service_IsDeleted",
                table: "Services",
                newName: "IX_Services_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShopsService_ServiceId",
                table: "BarberShopsServices",
                newName: "IX_BarberShopsServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShopsService_IsDeleted",
                table: "BarberShopsServices",
                newName: "IX_BarberShopsServices_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShopsService_BarberShopId",
                table: "BarberShopsServices",
                newName: "IX_BarberShopsServices_BarberShopId");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShop_TownId",
                table: "BarberShops",
                newName: "IX_BarberShops_TownId");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShop_OwnerId",
                table: "BarberShops",
                newName: "IX_BarberShops_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShop_IsDeleted",
                table: "BarberShops",
                newName: "IX_BarberShops_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_UserId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_ServiceId",
                table: "Appointments",
                newName: "IX_Appointments_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_IsDeleted",
                table: "Appointments",
                newName: "IX_Appointments_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_BarberShopId",
                table: "Appointments",
                newName: "IX_Appointments_BarberShopId");

            migrationBuilder.AddColumn<int>(
                name: "BarberServiceId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BarberServiceId",
                table: "BarberShops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Towns",
                table: "Towns",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberShopsServices",
                table: "BarberShopsServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberShops",
                table: "BarberShops",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BarberServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberServices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_BarberServiceId",
                table: "Services",
                column: "BarberServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BarberShops_BarberServiceId",
                table: "BarberShops",
                column: "BarberServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BarberServices_IsDeleted",
                table: "BarberServices",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_BarberShops_BarberShopId",
                table: "Appointments",
                column: "BarberShopId",
                principalTable: "BarberShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_BarberShopsServices_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "BarberShopsServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShops_AspNetUsers_OwnerId",
                table: "BarberShops",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShops_BarberServices_BarberServiceId",
                table: "BarberShops",
                column: "BarberServiceId",
                principalTable: "BarberServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShops_Towns_TownId",
                table: "BarberShops",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShopsServices_BarberShops_BarberShopId",
                table: "BarberShopsServices",
                column: "BarberShopId",
                principalTable: "BarberShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShopsServices_Services_ServiceId",
                table: "BarberShopsServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_BarberServices_BarberServiceId",
                table: "Services",
                column: "BarberServiceId",
                principalTable: "BarberServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_BarberShops_BarberShopId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_BarberShopsServices_ServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShops_AspNetUsers_OwnerId",
                table: "BarberShops");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShops_BarberServices_BarberServiceId",
                table: "BarberShops");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShops_Towns_TownId",
                table: "BarberShops");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShopsServices_BarberShops_BarberShopId",
                table: "BarberShopsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShopsServices_Services_ServiceId",
                table: "BarberShopsServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_BarberServices_BarberServiceId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "BarberServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Towns",
                table: "Towns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_BarberServiceId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberShopsServices",
                table: "BarberShopsServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberShops",
                table: "BarberShops");

            migrationBuilder.DropIndex(
                name: "IX_BarberShops_BarberServiceId",
                table: "BarberShops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "BarberServiceId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "BarberServiceId",
                table: "BarberShops");

            migrationBuilder.RenameTable(
                name: "Towns",
                newName: "Town");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "BarberShopsServices",
                newName: "BarberShopsService");

            migrationBuilder.RenameTable(
                name: "BarberShops",
                newName: "BarberShop");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_Towns_IsDeleted",
                table: "Town",
                newName: "IX_Town_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Services_IsDeleted",
                table: "Service",
                newName: "IX_Service_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShopsServices_ServiceId",
                table: "BarberShopsService",
                newName: "IX_BarberShopsService_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShopsServices_IsDeleted",
                table: "BarberShopsService",
                newName: "IX_BarberShopsService_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShopsServices_BarberShopId",
                table: "BarberShopsService",
                newName: "IX_BarberShopsService_BarberShopId");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShops_TownId",
                table: "BarberShop",
                newName: "IX_BarberShop_TownId");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShops_OwnerId",
                table: "BarberShop",
                newName: "IX_BarberShop_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShops_IsDeleted",
                table: "BarberShop",
                newName: "IX_BarberShop_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "Appointment",
                newName: "IX_Appointment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointment",
                newName: "IX_Appointment_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_IsDeleted",
                table: "Appointment",
                newName: "IX_Appointment_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_BarberShopId",
                table: "Appointment",
                newName: "IX_Appointment_BarberShopId");

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

            migrationBuilder.AddColumn<int>(
                name: "BarberShopServiceId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Town",
                table: "Town",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberShopsService",
                table: "BarberShopsService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberShop",
                table: "BarberShop",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_BarberShopServiceId",
                table: "Appointment",
                column: "BarberShopServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_UserId",
                table: "Appointment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_BarberShop_BarberShopId",
                table: "Appointment",
                column: "BarberShopId",
                principalTable: "BarberShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_BarberShopsService_BarberShopServiceId",
                table: "Appointment",
                column: "BarberShopServiceId",
                principalTable: "BarberShopsService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Service_ServiceId",
                table: "Appointment",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShop_AspNetUsers_OwnerId",
                table: "BarberShop",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShop_Town_TownId",
                table: "BarberShop",
                column: "TownId",
                principalTable: "Town",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShopsService_BarberShop_BarberShopId",
                table: "BarberShopsService",
                column: "BarberShopId",
                principalTable: "BarberShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShopsService_Service_ServiceId",
                table: "BarberShopsService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
