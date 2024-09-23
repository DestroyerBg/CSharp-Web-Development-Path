﻿// <auto-generated />
using System;
using CinemaApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaApp.Data.Context.Migrations
{
    [DbContext(typeof(CinemaAppContext))]
    [Migration("20240923092242_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CinemaApp.Data.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("331d700a-358a-4800-9970-bfb25865ef81"),
                            Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                            Director = "Frank Darabont",
                            Duration = 142,
                            Genre = "Drama",
                            ReleaseDate = new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Shawshank Redemption"
                        },
                        new
                        {
                            Id = new Guid("95586d11-77e5-4619-91ec-3eee2daaf2ef"),
                            Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                            Director = "Francis Ford Coppola",
                            Duration = 175,
                            Genre = "Crime",
                            ReleaseDate = new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Godfather"
                        },
                        new
                        {
                            Id = new Guid("f66bee7a-6b55-41f5-b3bc-1987ae023d41"),
                            Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
                            Director = "Christopher Nolan",
                            Duration = 152,
                            Genre = "Action",
                            ReleaseDate = new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Dark Knight"
                        },
                        new
                        {
                            Id = new Guid("93c984a5-ae7a-4946-9af7-cd7a72caef67"),
                            Description = "The lives of two mob hitmen, a boxer, a gangster, and his wife intertwine in four tales of violence and redemption.",
                            Director = "Quentin Tarantino",
                            Duration = 154,
                            Genre = "Crime",
                            ReleaseDate = new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pulp Fiction"
                        },
                        new
                        {
                            Id = new Guid("db942844-a052-4602-bd0a-7a4683bbcc7a"),
                            Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce.",
                            Director = "Steven Spielberg",
                            Duration = 195,
                            Genre = "Biography",
                            ReleaseDate = new DateTime(1993, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Schindler's List"
                        },
                        new
                        {
                            Id = new Guid("c2c19b2d-4a82-4b0c-83c6-0f2834ef9445"),
                            Description = "An insomniac office worker and a soap salesman form an underground fight club that evolves into much more.",
                            Director = "David Fincher",
                            Duration = 139,
                            Genre = "Drama",
                            ReleaseDate = new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Fight Club"
                        },
                        new
                        {
                            Id = new Guid("051732f3-25c9-4f7c-91cb-7410346cb380"),
                            Description = "The story of Forrest Gump, a slow-witted man who unintentionally becomes involved in every major event of the 20th century.",
                            Director = "Robert Zemeckis",
                            Duration = 142,
                            Genre = "Drama",
                            ReleaseDate = new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Forrest Gump"
                        },
                        new
                        {
                            Id = new Guid("56074d08-4507-4b97-afe9-a84be61e90cd"),
                            Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea.",
                            Director = "Christopher Nolan",
                            Duration = 148,
                            Genre = "Sci-Fi",
                            ReleaseDate = new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Inception"
                        },
                        new
                        {
                            Id = new Guid("69c2bb73-40ae-4102-a879-fac7cf9b82a5"),
                            Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                            Director = "Lana Wachowski, Lilly Wachowski",
                            Duration = 136,
                            Genre = "Sci-Fi",
                            ReleaseDate = new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Matrix"
                        },
                        new
                        {
                            Id = new Guid("95481d2b-7a78-487f-921b-7d01b4cb2bc5"),
                            Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom.",
                            Director = "Peter Jackson",
                            Duration = 201,
                            Genre = "Fantasy",
                            ReleaseDate = new DateTime(2003, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Lord of the Rings: The Return of the King"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
