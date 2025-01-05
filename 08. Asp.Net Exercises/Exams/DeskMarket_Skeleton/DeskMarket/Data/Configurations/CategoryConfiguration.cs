using DeskMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeskMarket.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedData());
        }

        private List<Category> SeedData()
        {
            List<Category> categories = new List<Category>()
            {
                new Category { Id = 1, Name = "Laptops" },
                new Category { Id = 2, Name = "Workstations" },
                new Category { Id = 3, Name = "Accessories" },
                new Category { Id = 4, Name = "Desktops" },
                new Category { Id = 5, Name = "Monitors" }
            };

            return categories;
        }
    }
}
