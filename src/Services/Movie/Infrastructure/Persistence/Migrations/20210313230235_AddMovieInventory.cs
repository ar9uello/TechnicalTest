using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTest.Movie.Persistence.Migrations
{
    public partial class AddMovieInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieInventoryStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieInventoryStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieLikes_Movies_MovieId1",
                        column: x => x.MovieId1,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    InventoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieStatusId = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieInventoryStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieInventories_MovieInventoryStatuses_MovieInventoryStatusId",
                        column: x => x.MovieInventoryStatusId,
                        principalTable: "MovieInventoryStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieInventories_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieInventories_MovieId",
                table: "MovieInventories",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieInventories_MovieInventoryStatusId",
                table: "MovieInventories",
                column: "MovieInventoryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLikes_MovieId1",
                table: "MovieLikes",
                column: "MovieId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieInventories");

            migrationBuilder.DropTable(
                name: "MovieLikes");

            migrationBuilder.DropTable(
                name: "MovieInventoryStatuses");
        }
    }
}
