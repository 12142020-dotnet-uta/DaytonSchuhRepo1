using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P0_DaytonSchuh.Migrations
{
    public partial class migration_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventories_locations_LocationID",
                table: "inventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventories",
                table: "inventories");

            migrationBuilder.DropIndex(
                name: "IX_inventories_LocationID",
                table: "inventories");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "inventories");

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryLocationID",
                table: "locations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventories",
                table: "inventories",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_locations_InventoryLocationID",
                table: "locations",
                column: "InventoryLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_locations_inventories_InventoryLocationID",
                table: "locations",
                column: "InventoryLocationID",
                principalTable: "inventories",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_inventories_InventoryLocationID",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_InventoryLocationID",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventories",
                table: "inventories");

            migrationBuilder.DropColumn(
                name: "InventoryLocationID",
                table: "locations");

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
                name: "IX_inventories_LocationID",
                table: "inventories",
                column: "LocationID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_inventories_locations_LocationID",
                table: "inventories",
                column: "LocationID",
                principalTable: "locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
