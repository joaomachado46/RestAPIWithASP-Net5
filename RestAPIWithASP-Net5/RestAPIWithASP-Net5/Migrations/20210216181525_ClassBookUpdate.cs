using Microsoft.EntityFrameworkCore.Migrations;

namespace RestAPIWithASP_Net5.Migrations
{
    public partial class ClassBookUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "books",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "books",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "LaunchDate",
                table: "books",
                newName: "launch_date");

            migrationBuilder.AddColumn<string>(
                name: "author",
                table: "books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "author",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "books",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "launch_date",
                table: "books",
                newName: "LaunchDate");
        }
    }
}
