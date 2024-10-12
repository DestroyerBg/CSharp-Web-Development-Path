using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Migrations
{
    public partial class TableGamerGamesNameCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamerGame_AspNetUsers_GamerId",
                table: "GamerGame");

            migrationBuilder.DropForeignKey(
                name: "FK_GamerGame_Games_GameId",
                table: "GamerGame");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamerGame",
                table: "GamerGame");

            migrationBuilder.RenameTable(
                name: "GamerGame",
                newName: "GamersGames");

            migrationBuilder.RenameIndex(
                name: "IX_GamerGame_GamerId",
                table: "GamersGames",
                newName: "IX_GamersGames_GamerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamersGames",
                table: "GamersGames",
                columns: new[] { "GameId", "GamerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_AspNetUsers_GamerId",
                table: "GamersGames",
                column: "GamerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_AspNetUsers_GamerId",
                table: "GamersGames");

            migrationBuilder.DropForeignKey(
                name: "FK_GamersGames_Games_GameId",
                table: "GamersGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GamersGames",
                table: "GamersGames");

            migrationBuilder.RenameTable(
                name: "GamersGames",
                newName: "GamerGame");

            migrationBuilder.RenameIndex(
                name: "IX_GamersGames_GamerId",
                table: "GamerGame",
                newName: "IX_GamerGame_GamerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GamerGame",
                table: "GamerGame",
                columns: new[] { "GameId", "GamerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GamerGame_AspNetUsers_GamerId",
                table: "GamerGame",
                column: "GamerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamerGame_Games_GameId",
                table: "GamerGame",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
