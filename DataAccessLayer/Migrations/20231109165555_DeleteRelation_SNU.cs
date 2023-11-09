using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class DeleteRelation_SNU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreNotifications_AspNetUsers_AppUserId",
                table: "StoreNotifications");

            migrationBuilder.DropIndex(
                name: "IX_StoreNotifications_AppUserId",
                table: "StoreNotifications");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "StoreNotifications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StoreNotifications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "StoreNotifications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StoreNotifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreNotifications_AppUserId",
                table: "StoreNotifications",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreNotifications_AspNetUsers_AppUserId",
                table: "StoreNotifications",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
