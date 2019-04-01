using Microsoft.EntityFrameworkCore.Migrations;

namespace GamifyFitness.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    lifetimeCalories = table.Column<float>(nullable: false),
                    currCaloriesStored = table.Column<float>(nullable: false),
                    Friends = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
