using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScratchWorld.Migrations
{
    /// <inheritdoc />
    public partial class ApprovedLandmark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_approved",
                schema: "public",
                table: "landmark",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_approved",
                schema: "public",
                table: "landmark");
        }
    }
}
