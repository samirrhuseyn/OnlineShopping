using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class UpdateStoreMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreMessages_AspNetUsers_AppUserId",
                table: "StoreMessages");

            migrationBuilder.DropIndex(
                name: "IX_StoreMessages_AppUserId",
                table: "StoreMessages");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "StoreMessages");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "StoreMessages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreMessages_UserID",
                table: "StoreMessages",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreMessages_AspNetUsers_UserID",
                table: "StoreMessages",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreMessages_AspNetUsers_UserID",
                table: "StoreMessages");

            migrationBuilder.DropIndex(
                name: "IX_StoreMessages_UserID",
                table: "StoreMessages");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "StoreMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "StoreMessages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreMessages_AppUserId",
                table: "StoreMessages",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreMessages_AspNetUsers_AppUserId",
                table: "StoreMessages",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
