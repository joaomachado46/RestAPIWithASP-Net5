using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestAPIWithASP_Net5.Migrations
{
    public partial class updateVerbPatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    refresh_token = table.Column<string>(nullable: true),
                    refresh_token_expiry_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "Id", "address", "Enabled", "first_name", "gender", "last_name" },
                values: new object[,]
                {
                    { 1, "Famalicão", false, "João", "Masculino", "Machado" },
                    { 2, "Famalicão", false, "Francisca", "Feminino", "Machado" },
                    { 3, "Famalicão", false, "Vânia", "Feminino", "Silva" },
                    { 4, "Famalicão", false, "Manel", "Masculino", "Antonio" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
