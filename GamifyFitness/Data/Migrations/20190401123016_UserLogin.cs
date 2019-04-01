using Microsoft.EntityFrameworkCore.Migrations;

namespace GamifyFitness.Migrations
{
    public partial class UserLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_logins",
                table: "logins");

            migrationBuilder.RenameTable(
                name: "logins",
                newName: "Logins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logins",
                table: "Logins",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logins",
                table: "Logins");

            migrationBuilder.RenameTable(
                name: "Logins",
                newName: "logins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_logins",
                table: "logins",
                column: "Email");
        }
    }
}
