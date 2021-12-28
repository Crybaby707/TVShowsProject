using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVShows.Data.Migrations
{
    public partial class ChangeDbName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Genres_GenreID1",
                table: "Contents");

            migrationBuilder.RenameColumn(
                name: "GenreID1",
                table: "Contents",
                newName: "GenreID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Contents",
                newName: "ContentID");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_GenreID1",
                table: "Contents",
                newName: "IX_Contents_GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Genres_GenreID",
                table: "Contents",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Genres_GenreID",
                table: "Contents");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                table: "Contents",
                newName: "GenreID1");

            migrationBuilder.RenameColumn(
                name: "ContentID",
                table: "Contents",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Contents_GenreID",
                table: "Contents",
                newName: "IX_Contents_GenreID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Genres_GenreID1",
                table: "Contents",
                column: "GenreID1",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
