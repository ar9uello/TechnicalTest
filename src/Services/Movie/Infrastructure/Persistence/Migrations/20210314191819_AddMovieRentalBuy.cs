using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTest.Movie.Persistence.Migrations
{
    public partial class AddMovieRentalBuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieBuys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieInventoryId = table.Column<int>(type: "int", nullable: false),
                    BuyDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuyPrice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieBuys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieBuys_MovieInventories_MovieInventoryId",
                        column: x => x.MovieInventoryId,
                        principalTable: "MovieInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieBuys_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieInventoryId = table.Column<int>(type: "int", nullable: false),
                    RentalBeginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalPrice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieRentals_MovieInventories_MovieInventoryId",
                        column: x => x.MovieInventoryId,
                        principalTable: "MovieInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieRentals_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieBuys_MovieId",
                table: "MovieBuys",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieBuys_MovieInventoryId",
                table: "MovieBuys",
                column: "MovieInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRentals_MovieId",
                table: "MovieRentals",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRentals_MovieInventoryId",
                table: "MovieRentals",
                column: "MovieInventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieBuys");

            migrationBuilder.DropTable(
                name: "MovieRentals");
        }
    }
}
