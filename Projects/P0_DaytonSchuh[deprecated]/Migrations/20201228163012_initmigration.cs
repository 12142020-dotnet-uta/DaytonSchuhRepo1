using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P0_DaytonSchuh.Migrations
{
    public partial class initmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "inventories",
                columns: table => new
                {
                    InventoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventories", x => x.InventoryID);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_orders_customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    LocationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_locations_inventories_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "inventories",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLog",
                columns: table => new
                {
                    LocationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdersOrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLog", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_OrderLog_locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLog_orders_OrdersOrderID",
                        column: x => x.OrdersOrderID,
                        principalTable: "orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_locations_InventoryID",
                table: "locations",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLog_OrdersOrderID",
                table: "OrderLog",
                column: "OrdersOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerID",
                table: "orders",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLog");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "inventories");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
