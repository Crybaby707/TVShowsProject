using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVShows.Data.Migrations
{
    public partial class AddTableContentGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentGenres",
                columns: table => new
                {
                    ContentGenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentGenres", x => x.ContentGenreId);
                    table.ForeignKey(
                        name: "FK_ContentGenres_Contents_ContentID",
                        column: x => x.ContentID,
                        principalTable: "Contents",
                        principalColumn: "ContentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentGenres_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentGenres_ContentID",
                table: "ContentGenres",
                column: "ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentGenres_GenreID",
                table: "ContentGenres",
                column: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentGenres");
        }
    }
}
