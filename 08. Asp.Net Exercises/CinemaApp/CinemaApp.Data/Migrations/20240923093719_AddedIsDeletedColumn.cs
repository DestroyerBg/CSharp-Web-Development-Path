using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDeletedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("051732f3-25c9-4f7c-91cb-7410346cb380"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("331d700a-358a-4800-9970-bfb25865ef81"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("56074d08-4507-4b97-afe9-a84be61e90cd"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("69c2bb73-40ae-4102-a879-fac7cf9b82a5"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("93c984a5-ae7a-4946-9af7-cd7a72caef67"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("95481d2b-7a78-487f-921b-7d01b4cb2bc5"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("95586d11-77e5-4619-91ec-3eee2daaf2ef"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c2c19b2d-4a82-4b0c-83c6-0f2834ef9445"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("db942844-a052-4602-bd0a-7a4683bbcc7a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f66bee7a-6b55-41f5-b3bc-1987ae023d41"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "IsDeleted", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("03b5c53c-c15d-4ca9-807d-70c83bf4eac7"), "The story of Forrest Gump, a slow-witted man who unintentionally becomes involved in every major event of the 20th century.", "Robert Zemeckis", 142, "Drama", false, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { new Guid("0a411fc9-4186-4fbd-b5c4-5e3ca1cb0464"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 175, "Crime", false, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("0e4fc412-a0e3-4e73-bd96-d53270965c45"), "The lives of two mob hitmen, a boxer, a gangster, and his wife intertwine in four tales of violence and redemption.", "Quentin Tarantino", 154, "Crime", false, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { new Guid("72e1c609-9952-4e5d-8df0-04bfc62c4f33"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Sci-Fi", false, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("7345847a-0a14-4546-a39f-b44e9835fe0e"), "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom.", "Peter Jackson", 201, "Fantasy", false, new DateTime(2003, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King" },
                    { new Guid("96926d24-e0d4-4242-a559-d67271a7cd7c"), "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce.", "Steven Spielberg", 195, "Biography", false, new DateTime(1993, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List" },
                    { new Guid("a7a553ca-4966-43b7-b83c-56936c10cf42"), "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", "Christopher Nolan", 152, "Action", false, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { new Guid("c7c39b7b-e025-4d12-b925-8c9cb070211e"), "An insomniac office worker and a soap salesman form an underground fight club that evolves into much more.", "David Fincher", 139, "Drama", false, new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club" },
                    { new Guid("d942d613-1437-40ef-9b9c-5b9043209680"), "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "Frank Darabont", 142, "Drama", false, new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("dbbcd5be-1c0e-4d55-98f2-1057d8f8a568"), "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea.", "Christopher Nolan", 148, "Sci-Fi", false, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("03b5c53c-c15d-4ca9-807d-70c83bf4eac7"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("0a411fc9-4186-4fbd-b5c4-5e3ca1cb0464"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("0e4fc412-a0e3-4e73-bd96-d53270965c45"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("72e1c609-9952-4e5d-8df0-04bfc62c4f33"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7345847a-0a14-4546-a39f-b44e9835fe0e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("96926d24-e0d4-4242-a559-d67271a7cd7c"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("a7a553ca-4966-43b7-b83c-56936c10cf42"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c7c39b7b-e025-4d12-b925-8c9cb070211e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d942d613-1437-40ef-9b9c-5b9043209680"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("dbbcd5be-1c0e-4d55-98f2-1057d8f8a568"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("051732f3-25c9-4f7c-91cb-7410346cb380"), "The story of Forrest Gump, a slow-witted man who unintentionally becomes involved in every major event of the 20th century.", "Robert Zemeckis", 142, "Drama", new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forrest Gump" },
                    { new Guid("331d700a-358a-4800-9970-bfb25865ef81"), "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "Frank Darabont", 142, "Drama", new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("56074d08-4507-4b97-afe9-a84be61e90cd"), "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea.", "Christopher Nolan", 148, "Sci-Fi", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { new Guid("69c2bb73-40ae-4102-a879-fac7cf9b82a5"), "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, "Sci-Fi", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { new Guid("93c984a5-ae7a-4946-9af7-cd7a72caef67"), "The lives of two mob hitmen, a boxer, a gangster, and his wife intertwine in four tales of violence and redemption.", "Quentin Tarantino", 154, "Crime", new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { new Guid("95481d2b-7a78-487f-921b-7d01b4cb2bc5"), "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom.", "Peter Jackson", 201, "Fantasy", new DateTime(2003, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King" },
                    { new Guid("95586d11-77e5-4619-91ec-3eee2daaf2ef"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 175, "Crime", new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("c2c19b2d-4a82-4b0c-83c6-0f2834ef9445"), "An insomniac office worker and a soap salesman form an underground fight club that evolves into much more.", "David Fincher", 139, "Drama", new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fight Club" },
                    { new Guid("db942844-a052-4602-bd0a-7a4683bbcc7a"), "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce.", "Steven Spielberg", 195, "Biography", new DateTime(1993, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schindler's List" },
                    { new Guid("f66bee7a-6b55-41f5-b3bc-1987ae023d41"), "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", "Christopher Nolan", 152, "Action", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" }
                });
        }
    }
}
