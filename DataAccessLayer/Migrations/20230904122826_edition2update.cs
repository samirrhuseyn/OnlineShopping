using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class edition2update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "İmage3",
                table: "Products",
                newName: "Image3");

            migrationBuilder.RenameColumn(
                name: "İmage2",
                table: "Products",
                newName: "Image2");

            migrationBuilder.RenameColumn(
                name: "İmage1",
                table: "Products",
                newName: "Image1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image3",
                table: "Products",
                newName: "İmage3");

            migrationBuilder.RenameColumn(
                name: "Image2",
                table: "Products",
                newName: "İmage2");

            migrationBuilder.RenameColumn(
                name: "Image1",
                table: "Products",
                newName: "İmage1");
        }
    }
}
