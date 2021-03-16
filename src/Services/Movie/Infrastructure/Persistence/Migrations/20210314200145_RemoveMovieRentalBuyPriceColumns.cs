using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTest.Movie.Persistence.Migrations
{
    public partial class RemoveMovieRentalBuyPriceColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieBuys_Movies_MovieId",
                table: "MovieBuys");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRentals_Movies_MovieId",
                table: "MovieRentals");

            migrationBuilder.DropIndex(
                name: "IX_MovieRentals_MovieId",
                table: "MovieRentals");

            migrationBuilder.DropIndex(
                name: "IX_MovieBuys_MovieId",
                table: "MovieBuys");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MovieRentals");

            migrationBuilder.DropColumn(
                name: "RentalPrice",
                table: "MovieRentals");

            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "MovieBuys");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MovieBuys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "MovieRentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalPrice",
                table: "MovieRentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BuyPrice",
                table: "MovieBuys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "MovieBuys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieRentals_MovieId",
                table: "MovieRentals",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieBuys_MovieId",
                table: "MovieBuys",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieBuys_Movies_MovieId",
                table: "MovieBuys",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRentals_Movies_MovieId",
                table: "MovieRentals",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
