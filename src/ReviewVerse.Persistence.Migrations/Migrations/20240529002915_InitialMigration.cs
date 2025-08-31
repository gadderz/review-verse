using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReviewVerse.Persistence.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameCategories",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "integer", nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                        ),
                    Name = table.Column<string>(
                        type: "character varying(200)",
                        maxLength: 200,
                        nullable: false
                    ),
                    CreatedAt = table.Column<DateTimeOffset>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    UpdatedAt = table.Column<DateTimeOffset>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    DeletedAt = table.Column<DateTimeOffset>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategories", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(
                        type: "character varying(200)",
                        maxLength: 200,
                        nullable: false
                    ),
                    Description = table.Column<string>(
                        type: "character varying(2000)",
                        maxLength: 2000,
                        nullable: false
                    ),
                    ReleaseDate = table.Column<DateTime>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    CreatedAt = table.Column<DateTimeOffset>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    UpdatedAt = table.Column<DateTimeOffset>(
                        type: "timestamp with time zone",
                        nullable: false
                    ),
                    DeletedAt = table.Column<DateTimeOffset>(
                        type: "timestamp with time zone",
                        nullable: true
                    ),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "GamesToGameCategories",
                columns: table => new
                {
                    GameCategoriesId = table.Column<int>(type: "integer", nullable: false),
                    GamesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_GamesToGameCategories",
                        x => new { x.GameCategoriesId, x.GamesId }
                    );
                    table.ForeignKey(
                        name: "FK_GamesToGameCategories_GameCategories_GameCategoriesId",
                        column: x => x.GameCategoriesId,
                        principalTable: "GameCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_GamesToGameCategories_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.InsertData(
                table: "GameCategories",
                columns: new[]
                {
                    "Id",
                    "CreatedAt",
                    "CreatedBy",
                    "DeletedAt",
                    "DeletedBy",
                    "Name",
                    "UpdatedAt",
                    "UpdatedBy"
                },
                values: new object[,]
                {
                    {
                        1,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "Action",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        2,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "Adventure",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        3,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "RPG",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        4,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "Simulation",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        5,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "Strategy",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        6,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "Sports",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        7,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "Puzzle",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        8,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "Racing",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        9,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "Horror",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        10,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "FPS",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        11,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "Fighting",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    },
                    {
                        12,
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null,
                        null,
                        null,
                        "MMO",
                        new DateTimeOffset(
                            new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            new TimeSpan(0, 0, 0, 0, 0)
                        ),
                        null
                    }
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_GamesToGameCategories_GamesId",
                table: "GamesToGameCategories",
                column: "GamesId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "GamesToGameCategories");

            migrationBuilder.DropTable(name: "GameCategories");

            migrationBuilder.DropTable(name: "Games");
        }
    }
}
