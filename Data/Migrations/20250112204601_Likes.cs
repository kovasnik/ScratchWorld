using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ScratchWorld.Migrations
{
    /// <inheritdoc />
    public partial class Likes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "parent_comment",
                schema: "public",
                table: "comment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "likes",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    region_id = table.Column<int>(type: "integer", nullable: true),
                    landmark_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_likes_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_likes_landmark_landmark_id",
                        column: x => x.landmark_id,
                        principalSchema: "public",
                        principalTable: "landmark",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_likes_region_region_id",
                        column: x => x.region_id,
                        principalSchema: "public",
                        principalTable: "region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_likes_landmark_id",
                schema: "public",
                table: "likes",
                column: "landmark_id");

            migrationBuilder.CreateIndex(
                name: "IX_likes_region_id",
                schema: "public",
                table: "likes",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_likes_user_id",
                schema: "public",
                table: "likes",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "likes",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "parent_comment",
                schema: "public",
                table: "comment");
        }
    }
}
