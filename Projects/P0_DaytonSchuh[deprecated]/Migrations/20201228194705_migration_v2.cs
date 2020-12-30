using Microsoft.EntityFrameworkCore.Migrations;

namespace P0_DaytonSchuh.Migrations
{
    public partial class migration_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_inventories_InventoryKey",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_InventoryKey",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "InventoryKey",
                table: "locations");

            migrationBuilder.RenameColumn(
                name: "InventoryID",
                table: "inventories",
                newName: "LocationID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventories_locations_LocationID",
                table: "inventories");

            migrationBuilder.DropIndex(
                name: "IX_inventories_LocationID",
                table: "inventories");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "inventories",
                newName: "InventoryID");

            migrationBuilder.AddColumn<int>(
                name: "InventoryKey",
                table: "locations",
                type: "int",
                nullable: true);

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
    }
}
