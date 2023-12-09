using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddedOrderStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatusID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    OrderStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusID",
                table: "Orders",
                column: "OrderStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusID",
                table: "Orders",
                column: "OrderStatusID",
                principalTable: "OrderStatuses",
                principalColumn: "OrderStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatusID",
                table: "Orders");
        }
    }
}
