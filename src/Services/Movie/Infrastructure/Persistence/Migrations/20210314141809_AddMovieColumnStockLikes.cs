using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTest.Movie.Persistence.Migrations
{
    public partial class AddMovieColumnStockLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Movies");
        }
    }
}
