using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Relation_SNU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "StoreNotifications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreNotifications_UserID",
                table: "StoreNotifications",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreNotifications_AspNetUsers_UserID",
                table: "StoreNotifications",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreNotifications_AspNetUsers_UserID",
                table: "StoreNotifications");

            migrationBuilder.DropIndex(
                name: "IX_StoreNotifications_UserID",
                table: "StoreNotifications");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "StoreNotifications");
        }
    }
}
