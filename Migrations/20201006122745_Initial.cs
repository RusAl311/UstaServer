using Microsoft.EntityFrameworkCore.Migrations;

namespace UstaApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Autos",
                table: "Autos");

            migrationBuilder.RenameTable(
                name: "Autos",
                newName: "Masters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Masters",
                table: "Masters",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Masters",
                table: "Masters");

            migrationBuilder.RenameTable(
                name: "Masters",
                newName: "Autos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autos",
                table: "Autos",
                column: "Id");
        }
    }
}
