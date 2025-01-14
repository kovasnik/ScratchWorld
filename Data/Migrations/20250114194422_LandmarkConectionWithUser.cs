using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScratchWorld.Migrations
{
    /// <inheritdoc />
    public partial class LandmarkConectionWithUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_shared",
                schema: "public",
                table: "landmark",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "public",
                table: "landmark",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_landmark_user_id",
                schema: "public",
                table: "landmark",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_landmark_AspNetUsers_user_id",
                schema: "public",
                table: "landmark",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_landmark_AspNetUsers_user_id",
                schema: "public",
                table: "landmark");

            migrationBuilder.DropIndex(
                name: "IX_landmark_user_id",
                schema: "public",
                table: "landmark");

            migrationBuilder.DropColumn(
                name: "is_shared",
                schema: "public",
                table: "landmark");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "public",
                table: "landmark");
        }
    }
}
