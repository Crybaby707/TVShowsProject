using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVShows.Data.Migrations
{
    public partial class Fix_ContentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHasRoles_Users_UserID",
                table: "UserHasRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersShowLists_Contents_ContentsID",
                table: "UsersShowLists");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersShowLists_Users_UserId",
                table: "UsersShowLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "ContentsID",
                table: "UsersShowLists",
                newName: "ContentID");

            migrationBuilder.RenameIndex(
                name: "IX_UsersShowLists_ContentsID",
                table: "UsersShowLists",
                newName: "IX_UsersShowLists_ContentID");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserHasRoles_User_UserID",
                table: "UserHasRoles",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersShowLists_Contents_ContentID",
                table: "UsersShowLists",
                column: "ContentID",
                principalTable: "Contents",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersShowLists_User_UserId",
                table: "UsersShowLists",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHasRoles_User_UserID",
                table: "UserHasRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersShowLists_Contents_ContentID",
                table: "UsersShowLists");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersShowLists_User_UserId",
                table: "UsersShowLists");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "ContentID",
                table: "UsersShowLists",
                newName: "ContentsID");

            migrationBuilder.RenameIndex(
                name: "IX_UsersShowLists_ContentID",
                table: "UsersShowLists",
                newName: "IX_UsersShowLists_ContentsID");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserHasRoles_Users_UserID",
                table: "UserHasRoles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersShowLists_Contents_ContentsID",
                table: "UsersShowLists",
                column: "ContentsID",
                principalTable: "Contents",
                principalColumn: "ContentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersShowLists_Users_UserId",
                table: "UsersShowLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
