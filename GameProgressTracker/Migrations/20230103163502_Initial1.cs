using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameProgressTracker.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameID",
                table: "Registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameOfPlatform",
                table: "Registrations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameID",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "NameOfPlatform",
                table: "Registrations");
        }
    }
}
