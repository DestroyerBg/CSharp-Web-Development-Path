using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cadastre.Migrations
{
    public partial class PropertyModelAddedInContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Districts_DistrictId",
                table: "Property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.RenameIndex(
                name: "IX_Property_DistrictId",
                table: "Properties",
                newName: "IX_Properties_DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Districts_DistrictId",
                table: "Properties",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Districts_DistrictId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_DistrictId",
                table: "Property",
                newName: "IX_Property_DistrictId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Districts_DistrictId",
                table: "Property",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
