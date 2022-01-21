using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVShows.Data.Migrations
{
    public partial class AddTableContentGenreFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Genres_GenreID",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_GenreID",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Contents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_GenreID",
                table: "Contents",
                column: "GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Genres_GenreID",
                table: "Contents",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
