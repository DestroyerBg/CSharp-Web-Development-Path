using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Common;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
            
        }

        public FootballBettingContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConstraints.DatabaseConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasMany(e => e.PrimaryKitTeams);
                entity.HasMany(e => e.SecondaryKitTeams);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(e => e.HomeTeam)
                    .WithMany()
                    .HasForeignKey(e => e.HomeTeamId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.AwayTeam)
                    .WithMany()
                    .HasForeignKey(e => e.AwayTeamId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasMany(e => e.HomeGames);
                entity.HasMany(e => e.AwayGames);
                entity.HasMany(e => e.Players);
                entity.HasOne(e => e.PrimaryKitColor)
                    .WithMany()
                    .HasForeignKey(e => e.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.SecondaryKitColor)
                    .WithMany()
                    .HasForeignKey(e => e.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.PlayerId });
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(e => e.Town)
                    .WithMany()
                    .HasForeignKey(e => e.TownId)
                    .OnDelete(DeleteBehavior.NoAction);
            });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }
    }
}
