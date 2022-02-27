using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INF27507_Boutique_En_Ligne.Migrations
{
    public partial class DefaultClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Balance", "Firstname", "Lastname", "Username" },
                values: new object[] { 1, 250.0, "Default", "User", "Default-User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
