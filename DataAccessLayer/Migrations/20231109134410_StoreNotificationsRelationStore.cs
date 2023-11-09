using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class StoreNotificationsRelationStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "StoreNotifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StoreNotifications_StoreID",
                table: "StoreNotifications",
                column: "StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreNotifications_Stores_StoreID",
                table: "StoreNotifications",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreNotifications_Stores_StoreID",
                table: "StoreNotifications");

            migrationBuilder.DropIndex(
                name: "IX_StoreNotifications_StoreID",
                table: "StoreNotifications");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "StoreNotifications");
        }
    }
}
