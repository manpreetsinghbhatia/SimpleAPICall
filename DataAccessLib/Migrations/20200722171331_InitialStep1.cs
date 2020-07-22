using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLib.Migrations
{
    public partial class InitialStep1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Maker = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShippingInfos",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zipcode = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    OrderID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShippingInfos_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "ID", "CreatedAt", "OrderDate", "Total" },
                values: new object[,]
                {
                    { new Guid("31568965-3cf6-4154-98e4-dba229b48afd"), new DateTime(2020, 7, 22, 13, 13, 30, 535, DateTimeKind.Local).AddTicks(4895), new DateTime(2020, 7, 22, 13, 13, 30, 535, DateTimeKind.Local).AddTicks(4928), 200.0 },
                    { new Guid("e7e9cfbd-1264-4d82-9ed2-482ee877d3c0"), new DateTime(2020, 7, 22, 13, 13, 30, 535, DateTimeKind.Local).AddTicks(6073), new DateTime(2020, 7, 22, 13, 13, 30, 535, DateTimeKind.Local).AddTicks(6092), 150.0 },
                    { new Guid("2442d361-70a3-4121-942b-4a314565c0d8"), new DateTime(2020, 7, 22, 13, 13, 30, 535, DateTimeKind.Local).AddTicks(6118), new DateTime(2020, 7, 22, 13, 13, 30, 535, DateTimeKind.Local).AddTicks(6122), 50.0 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CreatedAt", "Maker", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("50f0cab0-86e8-4205-acfb-dc092e455c8d"), new DateTime(2020, 7, 22, 13, 13, 30, 531, DateTimeKind.Local).AddTicks(1138), "SS", "Bat", 100.0 },
                    { new Guid("0fd43815-9fc7-4813-9c8c-4adc4ecc7861"), new DateTime(2020, 7, 22, 13, 13, 30, 534, DateTimeKind.Local).AddTicks(615), "SS", "Ball", 6.0 },
                    { new Guid("48af6f4e-ebee-4aca-a473-8b4b2ae50e90"), new DateTime(2020, 7, 22, 13, 13, 30, 534, DateTimeKind.Local).AddTicks(686), "SS", "Gloves", 10.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductID",
                table: "ProductDetail",
                column: "ProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingInfos_OrderID",
                table: "ShippingInfos",
                column: "OrderID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "ShippingInfos");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
