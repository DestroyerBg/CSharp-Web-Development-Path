using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ForumApp.Data.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateToCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("198aa6d1-e164-427d-91c0-013cfc1a3928"), "Content for post 4.", false, "Post 4" },
                    { new Guid("1d2dba7e-615e-43c8-82bd-6bfa210efeaa"), "Content for post 5.", false, "Post 5" },
                    { new Guid("3c72254f-b388-4c97-aaec-703352a80f59"), "Content for post 3.", false, "Post 3" },
                    { new Guid("aa1d2679-b42d-4a36-b42a-889fe348499d"), "Content for post 1.", false, "Post 1" },
                    { new Guid("d83a9259-a323-4cb3-8171-2a541ab8f837"), "Content for post 2.", false, "Post 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("198aa6d1-e164-427d-91c0-013cfc1a3928"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("1d2dba7e-615e-43c8-82bd-6bfa210efeaa"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3c72254f-b388-4c97-aaec-703352a80f59"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("aa1d2679-b42d-4a36-b42a-889fe348499d"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d83a9259-a323-4cb3-8171-2a541ab8f837"));

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Comments");

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
        }
    }
}
