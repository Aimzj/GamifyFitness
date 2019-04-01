using Microsoft.EntityFrameworkCore.Migrations;

namespace GamifyFitness.Migrations
{
    public partial class FitnessUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fitUsers",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fitUsers", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fitUsers");
        }
    }
}
