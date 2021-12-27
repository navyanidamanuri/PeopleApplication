using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleApplication.Migrations
{
    public partial class CreatePersonDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    CrtyCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrtyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.CrtyCode);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    CityCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityNmae = table.Column<string>(nullable: true),
                    CtryCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.CityCode);
                    table.ForeignKey(
                        name: "FK_cities_countries_CtryCode",
                        column: x => x.CtryCode,
                        principalTable: "countries",
                        principalColumn: "CrtyCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cities_CtryCode",
                table: "cities",
                column: "CtryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
