﻿using Cadastre.Data.Models;

namespace Cadastre.Data
{
    using Microsoft.EntityFrameworkCore;
    public class CadastreContext : DbContext
    {
        public CadastreContext()
        {
            
        }

        public CadastreContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<District> Districts { get; set; }
        public DbSet<Property> Properties { get; set; }

        public DbSet<Citizen> Citizens { get; set; }

        public DbSet<PropertyCitizen> PropertiesCitizens  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyCitizen>(entity =>
            {
                entity.HasKey(pk => new { pk.PropertyId, pk.CitizenId });
            });
        }
    }
}
