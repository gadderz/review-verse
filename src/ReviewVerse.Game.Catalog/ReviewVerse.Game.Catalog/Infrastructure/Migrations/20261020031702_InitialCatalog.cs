using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewVerse.Game.Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(name: "catalog");

            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS unaccent WITH SCHEMA public;");

            migrationBuilder.CreateTable(
                name: "games",
                schema: "catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.id);
                    table.CheckConstraint("ck_games_title", "btrim(title) <> ''");
                }
            );

            migrationBuilder.CreateTable(
                name: "platforms",
                schema: "catalog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platforms", x => x.id);
                    table.CheckConstraint("ck_platforms_name", "btrim(name) <> ''");
                }
            );

            migrationBuilder.CreateTable(
                name: "game_platforms",
                schema: "catalog",
                columns: table => new
                {
                    game_id = table.Column<Guid>(type: "uuid", nullable: false),
                    platform_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_platforms", x => new { x.game_id, x.platform_id });
                    table.ForeignKey(
                        name: "FK_game_platforms_games_game_id",
                        column: x => x.game_id,
                        principalSchema: "catalog",
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_game_platforms_platforms_platform_id",
                        column: x => x.platform_id,
                        principalSchema: "catalog",
                        principalTable: "platforms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_game_platforms_platform_id",
                schema: "catalog",
                table: "game_platforms",
                column: "platform_id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "game_platforms", schema: "catalog");

            migrationBuilder.DropTable(name: "games", schema: "catalog");

            migrationBuilder.DropTable(name: "platforms", schema: "catalog");
        }
    }
}
