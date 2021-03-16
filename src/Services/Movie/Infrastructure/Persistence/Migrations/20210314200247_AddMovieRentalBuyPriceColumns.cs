using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTest.Movie.Persistence.Migrations
{
    public partial class AddMovieRentalBuyPriceColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RentalPrice",
                table: "MovieRentals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDateTime",
                table: "MovieRentals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BuyPrice",
                table: "MovieBuys",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalPrice",
                table: "MovieRentals");

            migrationBuilder.DropColumn(
                name: "ReturnDateTime",
                table: "MovieRentals");

            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "MovieBuys");
        }
    }
}
