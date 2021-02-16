using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestAPIWithASP_Net5.Migrations
{
    public partial class InitialandSeedPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(nullable: false),
                    last_name = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "id", "address", "first_name", "gender", "last_name" },
                values: new object[,]
                {
                    { 1L, "Famalicão", "João", "Masculino", "Machado" },
                    { 2L, "Famalicão", "Francisca", "Feminino", "Machado" },
                    { 3L, "Famalicão", "Vânia", "Feminino", "Silva" },
                    { 4L, "Famalicão", "Manel", "Masculino", "Antonio" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
