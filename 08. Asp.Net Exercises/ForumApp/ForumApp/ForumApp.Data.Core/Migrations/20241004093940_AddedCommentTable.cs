using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ForumApp.Data.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddedCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("4a145efb-b308-42fc-bf31-1e63329a3d22"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("a13cd027-6f8a-48dd-a1c1-b3cae4b21193"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d591275e-10a0-4ac2-aa70-8ad791ab56ea"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("e819792c-9e28-487f-b164-03d30e7eed9c"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("ebd191a5-a0bb-41a5-b92c-8b7dcc91dc7c"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("69e79e53-ff51-4371-bcae-07b7346c3f6d"), "Content for post 1.", false, "Post 1" },
                    { new Guid("75f5061c-86c2-42cb-820f-867b0b9a503e"), "Content for post 3.", false, "Post 3" },
                    { new Guid("93070e41-5e9a-4ee0-b664-94bbdd538320"), "Content for post 2.", false, "Post 2" },
                    { new Guid("95dc603f-f95b-4418-a1d3-07629ba3e433"), "Content for post 5.", false, "Post 5" },
                    { new Guid("c79a031b-94df-4ab8-af83-262b02c95a4d"), "Content for post 4.", false, "Post 4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("69e79e53-ff51-4371-bcae-07b7346c3f6d"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("75f5061c-86c2-42cb-820f-867b0b9a503e"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("93070e41-5e9a-4ee0-b664-94bbdd538320"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("95dc603f-f95b-4418-a1d3-07629ba3e433"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("c79a031b-94df-4ab8-af83-262b02c95a4d"));

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
    }
}
