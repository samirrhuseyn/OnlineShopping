using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddReplyToReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReplyDateTime",
                table: "Replies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ReplyToReplies",
                columns: table => new
                {
                    ReplyToReplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyToReplyContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplyToReplyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReplyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyToReplies", x => x.ReplyToReplyID);
                    table.ForeignKey(
                        name: "FK_ReplyToReplies_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReplyToReplies_Replies_ReplyID",
                        column: x => x.ReplyID,
                        principalTable: "Replies",
                        principalColumn: "ReplyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReplyToReplies_ReplyID",
                table: "ReplyToReplies",
                column: "ReplyID");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyToReplies_UserID",
                table: "ReplyToReplies",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReplyToReplies");

            migrationBuilder.DropColumn(
                name: "ReplyDateTime",
                table: "Replies");
        }
    }
}
