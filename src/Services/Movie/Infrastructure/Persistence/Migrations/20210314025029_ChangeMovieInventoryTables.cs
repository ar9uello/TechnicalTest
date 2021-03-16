using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalTest.Movie.Persistence.Migrations
{
    public partial class ChangeMovieInventoryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieInventories_MovieInventoryStatuses_MovieInventoryStatusId",
                table: "MovieInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieLikes_Movies_MovieId1",
                table: "MovieLikes");

            migrationBuilder.DropIndex(
                name: "IX_MovieLikes_MovieId1",
                table: "MovieLikes");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                table: "MovieLikes");

            migrationBuilder.DropColumn(
                name: "MovieStatusId",
                table: "MovieInventories");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieLikes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieInventoryStatusId",
                table: "MovieInventories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieLikes_MovieId",
                table: "MovieLikes",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieInventories_MovieInventoryStatuses_MovieInventoryStatusId",
                table: "MovieInventories",
                column: "MovieInventoryStatusId",
                principalTable: "MovieInventoryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLikes_Movies_MovieId",
                table: "MovieLikes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieInventories_MovieInventoryStatuses_MovieInventoryStatusId",
                table: "MovieInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieLikes_Movies_MovieId",
                table: "MovieLikes");

            migrationBuilder.DropIndex(
                name: "IX_MovieLikes_MovieId",
                table: "MovieLikes");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "MovieLikes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MovieId1",
                table: "MovieLikes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieInventoryStatusId",
                table: "MovieInventories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MovieStatusId",
                table: "MovieInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovieLikes_MovieId1",
                table: "MovieLikes",
                column: "MovieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieInventories_MovieInventoryStatuses_MovieInventoryStatusId",
                table: "MovieInventories",
                column: "MovieInventoryStatusId",
                principalTable: "MovieInventoryStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLikes_Movies_MovieId1",
                table: "MovieLikes",
                column: "MovieId1",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
