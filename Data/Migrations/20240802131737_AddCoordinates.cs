using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScratchWorld.Migrations
{
    /// <inheritdoc />
    public partial class AddCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "coordinates",
                schema: "public",
                table: "landmark",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coordinates",
                schema: "public",
                table: "landmark");
        }
    }
}
