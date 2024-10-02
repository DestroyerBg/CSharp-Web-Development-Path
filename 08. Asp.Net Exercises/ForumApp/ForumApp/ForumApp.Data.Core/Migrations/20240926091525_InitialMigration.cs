using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ForumApp.Data.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("4a145efb-b308-42fc-bf31-1e63329a3d22"), "Content for post 1.", false, "Post 1" },
                    { new Guid("a13cd027-6f8a-48dd-a1c1-b3cae4b21193"), "Content for post 5.", false, "Post 5" },
                    { new Guid("d591275e-10a0-4ac2-aa70-8ad791ab56ea"), "Content for post 2.", false, "Post 2" },
                    { new Guid("e819792c-9e28-487f-b164-03d30e7eed9c"), "Content for post 4.", false, "Post 4" },
                    { new Guid("ebd191a5-a0bb-41a5-b92c-8b7dcc91dc7c"), "Content for post 3.", false, "Post 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
