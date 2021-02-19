using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestAPIWithASP_Net5.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    launch_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "Id", "address", "first_name", "gender", "last_name" },
                values: new object[,]
                {
                    { 1, "Famalicão", "João", "Masculino", "Machado" },
                    { 2, "Famalicão", "Francisca", "Feminino", "Machado" },
                    { 3, "Famalicão", "Vânia", "Feminino", "Silva" },
                    { 4, "Famalicão", "Manel", "Masculino", "Antonio" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
