using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Context.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasData(SeedData());
        }

        private List<Cinema> SeedData()
        {
            List<Cinema> cinemas = new List<Cinema>
            {
                new Cinema
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema City Mall of Sofia",
                    Location = "Sofia"
                },
                new Cinema
                {
                    Id = Guid.NewGuid(),
                    Name = "Arena Grand Mall Varna",
                    Location = "Varna"
                },
                new Cinema
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema City Plovdiv",
                    Location = "Plovdiv"
                },
                new Cinema
                {
                    Id = Guid.NewGuid(),
                    Name = "Cinema City Burgas Plaza",
                    Location = "Burgas"
                },
                new Cinema
                {
                    Id = Guid.NewGuid(),
                    Name = "Arena Park Mall Stara Zagora",
                    Location = "Stara Zagora"
                }
            };

            return cinemas;
        }
    }
}
