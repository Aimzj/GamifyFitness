using Microsoft.EntityFrameworkCore.Migrations;

namespace GamifyFitness.Migrations
{
    public partial class UserLogin3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Logins",
                newName: "emailExample");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "emailExample",
                table: "Logins",
                newName: "email");
        }
    }
}
