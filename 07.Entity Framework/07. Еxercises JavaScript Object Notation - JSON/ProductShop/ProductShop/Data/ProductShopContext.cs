using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductShop.Models;

namespace ProductShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
            
        }

        public ProductShopContext(DbContextOptions<ProductShopContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(pk => new { pk.CategoryId, pk.ProductId });

                entity.HasOne(e => e.Category)
                    .WithMany(e => e.CategoryProducts)
                    .HasForeignKey(e => e.CategoryId);

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.CategoryProducts)
                    .HasForeignKey(e => e.ProductId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(e => e.Buyer)
                    .WithMany(b => b.ProductsBought)
                    .HasForeignKey(e => e.BuyerId)
                    .IsRequired(false);
            });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoriesProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
