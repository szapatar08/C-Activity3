using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace C_Activity3.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Misions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Planet = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Risk = table.Column<string>(type: "text", nullable: false),
                    MisionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registers_Misions_MisionId",
                        column: x => x.MisionId,
                        principalTable: "Misions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Misions_AstronautId",
                table: "Misions",
                column: "AstronautId");

            migrationBuilder.CreateIndex(
                name: "IX_Misions_SpaceshipId",
                table: "Misions",
                column: "SpaceshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Registers_MisionId",
                table: "Registers",
                column: "MisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Misions_Astronauts_AstronautId",
                table: "Misions",
                column: "AstronautId",
                principalTable: "Astronauts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Misions_Spaceships_SpaceshipId",
                table: "Misions",
                column: "SpaceshipId",
                principalTable: "Spaceships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Misions_Astronauts_AstronautId",
                table: "Misions");

            migrationBuilder.DropForeignKey(
                name: "FK_Misions_Spaceships_SpaceshipId",
                table: "Misions");

            migrationBuilder.DropTable(
                name: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Misions_AstronautId",
                table: "Misions");

            migrationBuilder.DropIndex(
                name: "IX_Misions_SpaceshipId",
                table: "Misions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Misions");
        }
    }
}
