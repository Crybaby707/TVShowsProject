using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVShows.Data.Migrations
{
    public partial class WithContentGenreTableFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentGenres_Contents_ContentID",
                table: "ContentGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentGenres_Genres_GenreID",
                table: "ContentGenres");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentGenres_Contents_ContentID",
                table: "ContentGenres",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ContentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentGenres_Genres_GenreID",
                table: "ContentGenres",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentGenres_Contents_ContentID",
                table: "ContentGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_ContentGenres_Genres_GenreID",
                table: "ContentGenres");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentGenres_Contents_ContentID",
                table: "ContentGenres",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentGenres_Genres_GenreID",
                table: "ContentGenres",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
