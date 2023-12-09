using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UpdateNewOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderDetailId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "Orders",
                newName: "Count");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Orders",
                newName: "OrderDetailId");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDetailId",
                table: "Orders",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailId",
                table: "Orders",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
