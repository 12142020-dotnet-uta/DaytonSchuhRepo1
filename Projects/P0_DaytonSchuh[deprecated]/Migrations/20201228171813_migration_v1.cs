using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P0_DaytonSchuh.Migrations
{
    public partial class migration_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_inventories_InventoryID",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_InventoryID",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventories",
                table: "inventories");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "locations");

            migrationBuilder.AddColumn<int>(
                name: "InventoryKey",
                table: "locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Key",
                table: "inventories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventories",
                table: "inventories",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_locations_InventoryKey",
                table: "locations",
                column: "InventoryKey");

            migrationBuilder.AddForeignKey(
                name: "FK_locations_inventories_InventoryKey",
                table: "locations",
                column: "InventoryKey",
                principalTable: "inventories",
                principalColumn: "Key",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_inventories_InventoryKey",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_InventoryKey",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventories",
                table: "inventories");

            migrationBuilder.DropColumn(
                name: "InventoryKey",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "inventories");

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryID",
                table: "locations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventories",
                table: "inventories",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_locations_InventoryID",
                table: "locations",
                column: "InventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_locations_inventories_InventoryID",
                table: "locations",
                column: "InventoryID",
                principalTable: "inventories",
                principalColumn: "InventoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
