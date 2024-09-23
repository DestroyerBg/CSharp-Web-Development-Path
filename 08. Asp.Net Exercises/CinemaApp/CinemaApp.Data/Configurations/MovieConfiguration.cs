using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Context.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(SeedData());
        }

        private List<Movie> SeedData()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "The Shawshank Redemption",
                    Genre = "Drama",
                    ReleaseDate = new DateTime(1994, 9, 23),
                    Director = "Frank Darabont",
                    Duration = 142,
                    Description =
                        "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "The Godfather",
                    Genre = "Crime",
                    ReleaseDate = new DateTime(1972, 3, 24),
                    Director = "Francis Ford Coppola",
                    Duration = 175,
                    Description =
                        "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "The Dark Knight",
                    Genre = "Action",
                    ReleaseDate = new DateTime(2008, 7, 18),
                    Director = "Christopher Nolan",
                    Duration = 152,
                    Description =
                        "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham."
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Pulp Fiction",
                    Genre = "Crime",
                    ReleaseDate = new DateTime(1994, 10, 14),
                    Director = "Quentin Tarantino",
                    Duration = 154,
                    Description =
                        "The lives of two mob hitmen, a boxer, a gangster, and his wife intertwine in four tales of violence and redemption."
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Schindler's List",
                    Genre = "Biography",
                    ReleaseDate = new DateTime(1993, 12, 15),
                    Director = "Steven Spielberg",
                    Duration = 195,
                    Description =
                        "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce."
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Fight Club",
                    Genre = "Drama",
                    ReleaseDate = new DateTime(1999, 10, 15),
                    Director = "David Fincher",
                    Duration = 139,
                    Description =
                        "An insomniac office worker and a soap salesman form an underground fight club that evolves into much more."
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Forrest Gump",
                    Genre = "Drama",
                    ReleaseDate = new DateTime(1994, 7, 6),
                    Director = "Robert Zemeckis",
                    Duration = 142,
                    Description =
                        "The story of Forrest Gump, a slow-witted man who unintentionally becomes involved in every major event of the 20th century."
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "Inception",
                    Genre = "Sci-Fi",
                    ReleaseDate = new DateTime(2010, 7, 16),
                    Director = "Christopher Nolan",
                    Duration = 148,
                    Description =
                        "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea."
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "The Matrix",
                    Genre = "Sci-Fi",
                    ReleaseDate = new DateTime(1999, 3, 31),
                    Director = "Lana Wachowski, Lilly Wachowski",
                    Duration = 136,
                    Description =
                        "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers."
                },
                new Movie
                {
                    Id = Guid.NewGuid(),
                    Title = "The Lord of the Rings: The Return of the King",
                    Genre = "Fantasy",
                    ReleaseDate = new DateTime(2003, 12, 17),
                    Director = "Peter Jackson",
                    Duration = 201,
                    Description =
                        "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom."
                }
            };
            return movies;
        }
    }
}

