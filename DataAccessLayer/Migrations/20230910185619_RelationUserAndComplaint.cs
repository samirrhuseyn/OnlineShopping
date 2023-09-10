using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class RelationUserAndComplaint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserID",
                table: "Complaints",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_AspNetUsers_UserID",
                table: "Complaints",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_AspNetUsers_UserID",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_UserID",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Complaints");
        }
    }
}
