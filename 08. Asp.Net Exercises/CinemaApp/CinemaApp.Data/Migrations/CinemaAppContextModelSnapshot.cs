﻿// <auto-generated />
using System;
using CinemaApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaApp.Data.Context.Migrations
{
    [DbContext(typeof(CinemaAppContext))]
    partial class CinemaAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CinemaApp.Data.Models.Cinema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3bddb4ae-6ba4-4feb-aafb-c23b3743f9da"),
                            IsDeleted = false,
                            Location = "Sofia",
                            Name = "Cinema City Mall of Sofia"
                        },
                        new
                        {
                            Id = new Guid("3c642f3e-dbf0-437d-9c21-cea104db5811"),
                            IsDeleted = false,
                            Location = "Varna",
                            Name = "Arena Grand Mall Varna"
                        },
                        new
                        {
                            Id = new Guid("585aecc6-641f-4d95-abaa-5f2283ff7b37"),
                            IsDeleted = false,
                            Location = "Plovdiv",
                            Name = "Cinema City Plovdiv"
                        },
                        new
                        {
                            Id = new Guid("f260f8d6-0873-4334-ad08-6e95ca20ff57"),
                            IsDeleted = false,
                            Location = "Burgas",
                            Name = "Cinema City Burgas Plaza"
                        },
                        new
                        {
                            Id = new Guid("e911313b-217d-4357-aa7c-9b762506e007"),
                            IsDeleted = false,
                            Location = "Stara Zagora",
                            Name = "Arena Park Mall Stara Zagora"
                        });
                });

            modelBuilder.Entity("CinemaApp.Data.Models.CinemaMovie", b =>
                {
                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CinemaId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("CinemaMovies");
                });

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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
                            Id = new Guid("6dba859f-2efd-422a-8cb9-6c887e7835b7"),
                            Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                            Director = "Frank Darabont",
                            Duration = 142,
                            Genre = "Drama",
                            IsDeleted = false,
                            ReleaseDate = new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Shawshank Redemption"
                        },
                        new
                        {
                            Id = new Guid("7f3469b3-bc6a-4d68-b487-183217e770ba"),
                            Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                            Director = "Francis Ford Coppola",
                            Duration = 175,
                            Genre = "Crime",
                            IsDeleted = false,
                            ReleaseDate = new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Godfather"
                        },
                        new
                        {
                            Id = new Guid("9a444059-3c40-4531-b451-e2b126e1f5b8"),
                            Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
                            Director = "Christopher Nolan",
                            Duration = 152,
                            Genre = "Action",
                            IsDeleted = false,
                            ReleaseDate = new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Dark Knight"
                        },
                        new
                        {
                            Id = new Guid("55d979d2-c197-4126-8f63-f2496e8af159"),
                            Description = "The lives of two mob hitmen, a boxer, a gangster, and his wife intertwine in four tales of violence and redemption.",
                            Director = "Quentin Tarantino",
                            Duration = 154,
                            Genre = "Crime",
                            IsDeleted = false,
                            ReleaseDate = new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pulp Fiction"
                        },
                        new
                        {
                            Id = new Guid("07eb098f-9ea0-4ac5-a2ff-c6162d1f6320"),
                            Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce.",
                            Director = "Steven Spielberg",
                            Duration = 195,
                            Genre = "Biography",
                            IsDeleted = false,
                            ReleaseDate = new DateTime(1993, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Schindler's List"
                        },
                        new
                        {
                            Id = new Guid("690e3664-0c08-420c-97af-55ed8e20df5b"),
                            Description = "An insomniac office worker and a soap salesman form an underground fight club that evolves into much more.",
                            Director = "David Fincher",
                            Duration = 139,
                            Genre = "Drama",
                            IsDeleted = false,
                            ReleaseDate = new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Fight Club"
                        },
                        new
                        {
                            Id = new Guid("de0001d0-6d75-4f90-b999-5b25298c861a"),
                            Description = "The story of Forrest Gump, a slow-witted man who unintentionally becomes involved in every major event of the 20th century.",
                            Director = "Robert Zemeckis",
                            Duration = 142,
                            Genre = "Drama",
                            IsDeleted = false,
                            ReleaseDate = new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Forrest Gump"
                        },
                        new
                        {
                            Id = new Guid("5dbf45ef-b27b-449a-a573-a7a29276d699"),
                            Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea.",
                            Director = "Christopher Nolan",
                            Duration = 148,
                            Genre = "Sci-Fi",
                            IsDeleted = false,
                            ReleaseDate = new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Inception"
                        },
                        new
                        {
                            Id = new Guid("f8b89256-d837-4d99-b867-d4557e5a8b69"),
                            Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                            Director = "Lana Wachowski, Lilly Wachowski",
                            Duration = 136,
                            Genre = "Sci-Fi",
                            IsDeleted = false,
                            ReleaseDate = new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Matrix"
                        },
                        new
                        {
                            Id = new Guid("0287613b-64c6-4354-8d5c-ec4a60659baa"),
                            Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom.",
                            Director = "Peter Jackson",
                            Duration = 201,
                            Genre = "Fantasy",
                            IsDeleted = false,
                            ReleaseDate = new DateTime(2003, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Lord of the Rings: The Return of the King"
                        });
                });

            modelBuilder.Entity("CinemaApp.Data.Models.CinemaMovie", b =>
                {
                    b.HasOne("CinemaApp.Data.Models.Cinema", "Cinema")
                        .WithMany("CinemaMovies")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaApp.Data.Models.Movie", "Movie")
                        .WithMany("CinemaMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Cinema", b =>
                {
                    b.Navigation("CinemaMovies");
                });

            modelBuilder.Entity("CinemaApp.Data.Models.Movie", b =>
                {
                    b.Navigation("CinemaMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
