using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection;
using CinemaApp.Data.Models;
using Microsoft.IdentityModel.Protocols;

namespace CinemaApp.Data.Context
{
    public class CinemaAppContext : DbContext
    {

        public CinemaAppContext(DbContextOptions<CinemaAppContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Default");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<CinemaMovie> CinemaMovies { get; set; }

    }
}
