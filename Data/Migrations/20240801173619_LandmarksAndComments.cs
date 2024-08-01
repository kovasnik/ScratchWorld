using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ScratchWorld.Migrations
{
    /// <inheritdoc />
    public partial class LandmarksAndComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "map_id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "public",
                table: "region",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "landmark",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    region_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_landmark", x => x.id);
                    table.ForeignKey(
                        name: "FK_landmark_region_region_id",
                        column: x => x.region_id,
                        principalSchema: "public",
                        principalTable: "region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment_text = table.Column<string>(type: "text", nullable: false),
                    comment_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    region_id = table.Column<int>(type: "integer", nullable: true),
                    landmark_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_comment_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_landmark_landmark_id",
                        column: x => x.landmark_id,
                        principalSchema: "public",
                        principalTable: "landmark",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_comment_region_region_id",
                        column: x => x.region_id,
                        principalSchema: "public",
                        principalTable: "region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_landmark_id",
                schema: "public",
                table: "comment",
                column: "landmark_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_region_id",
                schema: "public",
                table: "comment",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_user_id",
                schema: "public",
                table: "comment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_landmark_region_id",
                schema: "public",
                table: "landmark",
                column: "region_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment",
                schema: "public");

            migrationBuilder.DropTable(
                name: "landmark",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "public",
                table: "region");

            migrationBuilder.AddColumn<int>(
                name: "map_id",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);
        }
    }
}
