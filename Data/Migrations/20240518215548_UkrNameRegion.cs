using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScratchWorld.Migrations
{
    /// <inheritdoc />
    public partial class UkrNameRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ukr_name",
                schema: "public",
                table: "region",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ukr_name",
                schema: "public",
                table: "region");
        }
    }
}
