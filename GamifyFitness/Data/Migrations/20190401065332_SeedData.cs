using Microsoft.EntityFrameworkCore.Migrations;

namespace GamifyFitness.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Friends", "age", "currCaloriesStored", "lifetimeCalories", "name" },
                values: new object[] { "1", "Aimee,Riordan", 22, 10f, 100f, "Ronan," });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "1");
        }
    }
}
