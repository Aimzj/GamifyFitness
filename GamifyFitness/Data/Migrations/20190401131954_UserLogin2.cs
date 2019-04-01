using Microsoft.EntityFrameworkCore.Migrations;

namespace GamifyFitness.Migrations
{
    public partial class UserLogin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "1",
                columns: new[] { "Email", "Password" },
                values: new object[] { "constantineronan@gmail.com", "Ronan123!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: "1",
                columns: new[] { "Email", "Password" },
                values: new object[] { null, null });
        }
    }
}
