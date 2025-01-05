using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskMarket.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrlNameFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasImageUrl",
                table: "Products",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "HasImageUrl");
        }
    }
}
