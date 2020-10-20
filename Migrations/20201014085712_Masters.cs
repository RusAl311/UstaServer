using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UstaApi.Migrations
{
    public partial class Masters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Masters",
                table: "Masters");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Masters");

            migrationBuilder.AddColumn<int>(
                name: "MasterId",
                table: "Masters",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Masters",
                table: "Masters",
                column: "MasterId");

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    SpecialityId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.SpecialityId);
                });

            migrationBuilder.CreateTable(
                name: "MasterSpecialities",
                columns: table => new
                {
                    MasterId = table.Column<int>(nullable: false),
                    SpecialityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSpecialities", x => new { x.MasterId, x.SpecialityId });
                    table.ForeignKey(
                        name: "FK_MasterSpecialities_Masters_MasterId",
                        column: x => x.MasterId,
                        principalTable: "Masters",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterSpecialities_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "SpecialityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterSpecialities_SpecialityId",
                table: "MasterSpecialities",
                column: "SpecialityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterSpecialities");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Masters",
                table: "Masters");

            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "Masters");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Masters",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Masters",
                table: "Masters",
                column: "Id");
        }
    }
}
